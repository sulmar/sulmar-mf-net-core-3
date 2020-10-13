using MF.Rb.Domain;
using MF.Rb.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MF.Rb.Api.Controllers
{

    // api/reports


    [Route("api/{controller}")]
    public class ReportsController : ControllerBase
    {
        // readonly - powoduje, że wartość zmiennej możemy przypisać tylko w konstruktorze
        private readonly IReportRepository reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        // GET api/reports

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Hello World!");
        //}

        // GET api/reports?dysponentId=1

        [HttpGet]
        public IActionResult Get([FromQuery] int dysponentId)
        {
            IEnumerable<Report> reports = reportRepository.Get(dysponentId);

            // Metoda OK - tworzy obiekt odpowiedzi 200 OK 
            // i dokonuje serializacji danych domyślnie w formacie JSON

            return Ok(reports);

        }

        // GET api/dysponents/{dysponentId}/reports

        [HttpGet("~/api/dysponents/{dysponentId}/{controller}")]
        public IActionResult GetByDysponent(int dysponentId)
        {
            IEnumerable<Report> reports = reportRepository.Get(dysponentId);

            // Metoda OK - tworzy obiekt odpowiedzi 200 OK 
            // i dokonuje serializacji danych domyślnie w formacie JSON

            return Ok(reports);
        }

        // GET api/reports/{reportId}

        [HttpGet("{reportId}", Name = "GetById")]
        public IActionResult GetById(int reportId)
        {
            Report report = reportRepository.GetById(reportId);

            return Ok(report);
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        //{
        //    IEnumerable<Report> reports = reportRepository.Get(from, to);

        //    return Ok(reports);
        //}


        // POST /api/reports

        [HttpPost]
        public IActionResult Post([FromBody] Report report)
        {
            reportRepository.Add(report);

            // 201 Created
            // location: http://localhost:5000/api/reports/{id}
            // body: {json}

           
            return CreatedAtRoute("GetById", new { reportId = report.Id }, report );

        }
         
        // PUT api/reports/1   - zamień (usuń stary i wstaw nowy)
        [HttpPut("{reportId}")]
        public IActionResult Put(int reportId, Report report)
        {
            if (reportId!=report.Id)
            {
                return BadRequest();
            }

            reportRepository.Update(report);

            return NoContent();
        }

        // PATCH api/reports/1  - zmień (modyfikuje tylko wybrane elementy)
        [HttpPatch]
        public IActionResult Patch(int reportId, Report report)
        {
            // JsonPatch
            // http://jsonpatch.com/


            throw new NotImplementedException();
        }

        [HttpDelete("{reportId}")]
        public IActionResult Delete(int reportId)
        {
            reportRepository.Remove(reportId);

            return NoContent();

        }


    }
}
