using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ARB.Models;
using ARB.Dtos;
using DnsClient;
using ARB.Controllers.API;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Reflection;

namespace ARB.Controllers.API
{

    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        private ApplicationDbContext _context;


        public PatientController()
        {
            _context = new ApplicationDbContext();


        }
        /*        public List<Patient> patients() {
                    var patient = _context.Patients
                                        .Include(p => p.ClinicalInfo)
                                        .Include(p => p.GeneralInfo)
                                        .Include(p => p.FinalAssessment)
                                        *//*  .Include(p => p.ExamData)*//*
                                        .ToList();
                    return patient;
                }*/
        public List<ClinicalInfo> clinicalInfos()
        {
            var clinicalInfos = _context.ClinicalInfos
                                       .Include(c => c.Asymmetries)
                                       .Include(c => c.SuspiciousMorphology)
                                       .Include(c => c.TypicallyBenign)
                                       .Include(c => c.Features)
                                       .Include(c => c.Distribution)
                                       .Include(c => c.MassSpecifications)
                                       .ToList();
            return clinicalInfos;
        }

        public List<FinalAssessment> finalAssessments()
        {
            return (_context.FinalAssessments
                .Include(f => f.BiRads)
                .Include(f => f.Recommendation).ToList());
        }
        Patient getPatientRecord (int id)
        {

            var existingPatient = _context.Patients
                                        .Where(p => p.Id == id)
                                        .Include(p => p.ClinicalInfo)
                                        .Include(p => p.ClinicalInfo.Asymmetries)
                                        .Include(p => p.ClinicalInfo.SuspiciousMorphology)
                                        .Include(p => p.ClinicalInfo.TypicallyBenign)
                                        .Include(p => p.ClinicalInfo.Features)
                                        .Include(p => p.ClinicalInfo.Distribution)
                                        .Include(p=>p.ClinicalInfo.MassSpecifications)
                                        .Include(p => p.GeneralInfo)
                                        .Include(p => p.FinalAssessment)
                                        .Include(p => p.FinalAssessment.BiRads)
                                        .Include(p => p.FinalAssessment.BiRads)
                                        .Include(p => p.FinalAssessment.Recommendation)
                                        .SingleOrDefault();
            return (existingPatient);
        }

        ClinicalInfo GetClinicalInfo(int id)
        {
            var clinicalInfo = _context.ClinicalInfos
                                        .Where(c=>c.Id==id)
                                        .Include(c => c.Asymmetries)
                                        .Include(c => c.SuspiciousMorphology)
                                        .Include(c => c.TypicallyBenign)
                                        .Include(c => c.Features)
                                        .Include(c => c.Distribution)
                                        .Include(c => c.MassSpecifications)
                                        .SingleOrDefault();
            return (clinicalInfo);
        }

        List<MassSpecification> GetMassSpecifications(int id)
        {
            var massSpecifications = _context.MassSpecifications
                                       .Where(m => m.ClinicalInfoId == id)
                                       .Include(c => c.ClockFace)
                                       .Include(c => c.MassMargin)
                                       .Include(c => c.MassDensity)
                                       .Include(c => c.Quadrant)
                                       .ToList();
                                      
            return massSpecifications;

        } 

        FinalAssessment getFinalAssessment(int id)
        {
            return (_context.FinalAssessments
                                            .Include(f => f.BiRads)
                                            .Include(f => f.Recommendation)
                                            .SingleOrDefault(c => c.Id == id)
                                            );

        }
       
        StringBuilder sb = new StringBuilder();
        private string m_exePath = string.Empty;
        public void LogWrite(string logMessage)
        {
            m_exePath = "C:\\Users\\EG\\source\\repos\\New folder\\ARB";
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception)
            {
            }
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }




        // GET api/<controller>
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {

            return Ok(_context.Patients.ToList());
        }


        // GET api/<controller>/5
        [Route("{id}/{by}")]
        [HttpGet]
        public IHttpActionResult Get(int id, string by)
        {
            Patient patient = new Patient();

            if (by == "\"examId\"")
            {
                var patientInDb = _context.Patients.FirstOrDefault(p => p.ExamDataId == id);

                if(patientInDb != null)
                {
                    var patientId = patientInDb.Id;
                    patient = getPatientRecord(patientId);
                }

            }
            else
            {
                patient = getPatientRecord(id);

            }

          
            
            if (patient == null)
                return NotFound();

            patient.ClinicalInfo.MassSpecifications = GetMassSpecifications(patient.Id);

          /*  string message = $"Patient In Get by id Request: { JsonConvert.SerializeObject(patient) }";
            LogWrite(message);*/


            return Ok(Mapper.Map<Patient, PatientDto>(patient));
        }






        // POST api/<controller>


        [Route("")]
        [HttpPost]

        public IHttpActionResult Post([FromBody] Patient patient)
        {
            var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

            if (!ModelState.IsValid)
                return Ok(errors);


            var examDataCount = _context.ExamDatas.Count(c => c.Id == patient.ExamDataId);
            
            if ( examDataCount > 1 )
            {
                return Ok("already Exist");
            }
            
           else if (examDataCount == 0 )
            {
                
              return Ok("Please, Add Patient Exam Data Information First");
                
            }

           
            
     

            _context.Patients.Add(patient);

            _context.SaveChanges();

            Patient patientFromDataBase = getPatientRecord(patient.Id);
            
            patientFromDataBase.ClinicalInfo.MassSpecifications = GetMassSpecifications(patient.Id);

            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientFromDataBase);


        }



        // PUT api/<controller>/5
        [Route("{id}")]
        [HttpPut]

        public IHttpActionResult Put([FromUri] int id, [FromBody] PatientDto newPatient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingPatient = getPatientRecord(id);



            if (existingPatient != null)
            {
                    // Update 
                    _context.Entry(existingPatient).CurrentValues.SetValues(newPatient);

                    var existingClinicalInfo = _context.ClinicalInfos
                            .SingleOrDefault(c => c.Id == existingPatient.ClinicalInfo.Id);

                    var existingGeneralInfo = _context.GeneralInfos.SingleOrDefault(g => g.Id == existingPatient.GeneralInfo.Id);

                var existingFinalAssessment = _context.FinalAssessments.SingleOrDefault(f=>f.Id == existingPatient.FinalAssessment.Id);
                //var existingFinalAssessment = getFinalAssessment(existingPatient.FinalAssessment.Id);
                //existingFinalAssessment.BiRads = newPatient.FinalAssessment.BiRads;                //existingFinalAssessment.Recommendation = newPatient.FinalAssessment.Recommendation;
                string mess = $"Patient In PUT Request: { JsonConvert.SerializeObject(existingPatient.FinalAssessment)}";

                System.Diagnostics.Debug.WriteLine(mess);

                mess = $"Patient In PUT Requestss: { JsonConvert.SerializeObject(newPatient.FinalAssessment)}";

                System.Diagnostics.Debug.WriteLine(mess);
                var existingFeatures = _context.Features.SingleOrDefault(f => f.Id == existingPatient.ClinicalInfo.Features.Id);

                    var existingMassSpecifications = GetMassSpecifications(id);

                var newExistingMassSpecifications = newPatient.ClinicalInfo.MassSpecifications.ToList();
               
                if (existingClinicalInfo != null && existingGeneralInfo != null && existingFinalAssessment != null)
                { 
                    _context.Entry(existingClinicalInfo).CurrentValues.SetValues(newPatient.ClinicalInfo);
                
                    _context.Entry(existingGeneralInfo).CurrentValues.SetValues(newPatient.GeneralInfo);
                    
                    _context.Entry(existingFinalAssessment).CurrentValues.SetValues(newPatient.FinalAssessment);
                    
                    _context.Entry(existingFeatures).CurrentValues.SetValues(newPatient.ClinicalInfo.Features);

                    var counter = 0;
                    
                    var lengthOf_NewMasses = newExistingMassSpecifications.Count();
                    
                    var lenthgOf_existingMasses = existingMassSpecifications.Count();
                    
                    if (lengthOf_NewMasses >= lenthgOf_existingMasses) // Add Masses
                    {
                        foreach (var element in newExistingMassSpecifications)
                        {
                            if (counter < lenthgOf_existingMasses)
                            {
                                _context.Entry(existingMassSpecifications[counter]).CurrentValues.SetValues(element);
                            }
                            else
                            {
                                _context.MassSpecifications.Add(element);
                            }
                            counter += 1;
                        }

                    }
                    else    // Delete 
                    {
                        foreach (var element in existingMassSpecifications)
                        {
                            if (counter < lengthOf_NewMasses && lengthOf_NewMasses != 0)
                            {
                                _context.Entry(element).CurrentValues.SetValues(newExistingMassSpecifications[counter]);

                            }
                            else
                            {
                                _context.MassSpecifications.Remove(element);
                            }
                            counter += 1;
                        }

                    }
                   
                    /*  foreach(var element in newPatient.ClinicalInfo.MassSpecifications)
                      {
                          var check = existingMassSpecifications.Where(c => c.Id == element.Id).SingleOrDefault();

                          if(check == null)
                          {
                              _context.MassSpecifications.Add(element);


                          }

                      }

                      foreach (var element in existingMassSpecifications)
                      {
                          var MassSpecificationInNewPatient = newPatient.ClinicalInfo.MassSpecifications.Where(c => c.Id == element.Id).SingleOrDefault();

                          var massSpecfictionMember = existingMassSpecifications.Where(c => c.Id == element.Id).SingleOrDefault();


                          if (MassSpecificationInNewPatient != null)
                                  {

                                      _context.Entry(massSpecfictionMember).CurrentValues.SetValues(MassSpecificationInNewPatient);


                                  }
                          else
                          {
                              _context.MassSpecifications.Remove(massSpecfictionMember);

                          }


                      }*/

                }
                    else
                        {
                            return NotFound();

                        }


                    _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }





            string message = $"Patient In PUT Request: { JsonConvert.SerializeObject(existingPatient)}";

            System.Diagnostics.Debug.WriteLine(message);

            

            return Ok(existingPatient);
        }

        // DELETE api/<controller>/5
        [Route("{id}")]
        [HttpDelete]

        public IHttpActionResult Delete(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(g => g.Id == id);
            if (patientInDb == null)
                return NotFound();

            var clincalinfoInDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == patientInDb.ClinicalInfo.Id);
            var featuresInDb = _context.Features.SingleOrDefault(c => c.Id == clincalinfoInDb.Features.Id);
            var GeneralInfoInDb = _context.GeneralInfos.SingleOrDefault(c => c.Id == patientInDb.GeneralInfo.Id);
            var FinalAssesmentInDb = _context.FinalAssessments.SingleOrDefault(f => f.Id == patientInDb.FinalAssessment.Id);
            var RecommendationInDb = _context.Recommendations.SingleOrDefault(r => r.Id == FinalAssesmentInDb.Recommendation.Id);

          


            _context.Features.Remove(featuresInDb);
            _context.ClinicalInfos.Remove(clincalinfoInDb);
            _context.GeneralInfos.Remove(GeneralInfoInDb);
            _context.Recommendations.Remove(RecommendationInDb);
            _context.FinalAssessments.Remove(FinalAssesmentInDb);
            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}


//var patientInDb = _context.Patients.SingleOrDefault(g => g.Id == id);

//if (patientInDb == null)
//    return NotFound();


//patientInDb = Mapper.Map(patientDto, patientInDb);

//var clinicalInfo = _context.ClinicalInfos.SingleOrDefault(c => c.Id == patientDto.ClinicalInfoId);

//clinicalInfo = Mapper.Map(patientInDb.ClinicalInfo, clinicalInfo);

//_context.Entry(patientInDb).State = System.Data.Entity.EntityState.Modified;

//_context.Entry(clinicalInfo).State = System.Data.Entity.EntityState.Modified;


//_context.SaveChanges();