using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ARB.Models;
using ARB.Dtos;


namespace ARB.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<FinalAssessment, FinalAssessmentDto>();
            Mapper.CreateMap<BiRads, BiRadsDto>();
            Mapper.CreateMap<Recommendation, RecommendationDto>();
            Mapper.CreateMap<ClinicalInfo, ClinicalInfoDto>();
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<ExamData, ExamDataDto>();

            Mapper.CreateMap<GeneralInfo, GeneralInfoDto>();

            Mapper.CreateMap<FinalAssessmentDto, FinalAssessment>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<BiRadsDto, BiRads>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<RecommendationDto, Recommendation>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<GeneralInfoDto, GeneralInfo>()
                .ForMember(c => c.Id, opt => opt.Ignore());   
            Mapper.CreateMap<PatientDto, Patient>()
                  .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<DoctorDto, Doctor>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ClinicalInfoDto, ClinicalInfo>()
            .ForMember(c => c.Id, opt => opt.Ignore());
            
            Mapper.CreateMap<ExamDataDto, ExamData>()
            .ForMember(c => c.Id, opt => opt.Ignore());


        }

    
    }
}