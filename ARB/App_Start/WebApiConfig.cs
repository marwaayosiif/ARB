using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ARB
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var corsAttr = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(corsAttr);
			var settings = config.Formatters.JsonFormatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Formatting = Formatting.Indented;

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			

			config.Routes.MapHttpRoute("DefaultApiWithId", "Api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
			config.Routes.MapHttpRoute("DefaultApiWithAction", "Api/{controller}/{action}");
			/*config.Routes.MapHttpRoute("DefaultApiGet", "Api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
			config.Routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
		*/}
	}
}

/*{
	"name": "name",
"birthDate": "12Dec1999",
"modality": "Mamaograph",
"status": "incomplete",
"clinicalInfo":
	{

		"id": 1,
		"breastCompostion": "a",
		"numOfMass": 110,
		"asymmetries": null,
		"asyId": 0,
		"features": null,
		"featuresId": 0,
		"massShape": "oval",
		"massMargin": {
			"id": 2,
			"name": "Microlobulated"
		},
		"massMarginId": 2,
		"massDensity": {
			"id": 2,
			"name": "Equal density"
		},
		"massDensityId": 2,
		"typicallyBenign": {
			"id": 3,
			"name": "Large"
		},
		"typicallyBenignId": 3,
		"suspiciousMorphology": {
			"id": 3,
			"name": "Fine pleomorphic"
		},
		"suspiciousMorphologyId": 3,
		"distribution": null,
		"distributionId": 1,
		"laterality": "Right",
		"quadrant": {
			"id": 2,
			"name": "Lower inner"
		},
		"quadrantId": 2,
		"clockFace": {
			"id": 3,
			"name": 3
		},
		"clockFaceId": 3,
		"depth": "12",
		"distanceFromTheNipple": "1"
},
"ClinicalInfoId": 1,
"GeneralInfo":
	{
		"id": 2,
		"examDate": "0001-01-01T00:00:00",
		"examReason": "Follow Up",
		"complain": null,
		"hadAMammogram": false,
		"whenHadAMammogram": null,
		"whereHadAMammogram": null,
		"historyOfMammogram": null,
		"personalHistoryOfBreastCancer": false,
		"mother": false,
		"motherAge": 0,
		"sister": false,
		"sisterAge": 0,
		"daughter": false,
		"daughterAge": 0,
		"grandmother": false,
		"grandmotherAge": 0,
		"aunt": false,
		"auntAge": 0,
		"cousin": false,
		"cousinAge": 0,
		"takingHormones": false,
		"howlongTakingHormones": null
	},

"GeneralInfoId": 2,
"FinalAssessment":
{

		"id": 6,
	"biRads": {
			"id": 2,
		"name": "1"
	},
	"recommendation": {
			"id": 2,
		"name": "MRI"
	},
	"recommendationId": 2,
	"recommendationText": "112",
	"conc": "11"

},
"FinalAssessmentId": 6
}

	   {
			"clinicalInfoId":1,
			"generalInfoId":1,
			"finalAssessmentId":1,
			"examDataId":1
			
		}
 
 
 [

		{
		"massShape": "oval",
		"massMarginId": 2,
		"massDensityId": 2,
		"distributionId": 1,
		"laterality": "Right",	
		"quadrantId": 2,
		"clockFaceId": 3,
		"depth": "12",
		"distanceFromTheNipple": "1"

		},
		{

		"massShape": "oval",
		"massMarginId": 2,
		"massDensityId": 2,
		"distributionId": 1,
		"laterality": "Right",	
		"quadrantId": 2,
		"clockFaceId": 3,
		"depth": "12",
		"distanceFromTheNipple": "1"
		}
]
 "massSpecifications":
		 [

			{
			"massShape": "oval",
			"massMarginId": 2,
			"massDensityId": 2,
			"distributionId": 1,
			"laterality": "Right",	
			"quadrantId": 2,
			"clockFaceId": 3,
			"depth": "12",
			"distanceFromTheNipple": "1"
			}
		]
 
 */