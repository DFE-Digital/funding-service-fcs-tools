using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuildQuery.WebApp.API
{
    using System.Text;
    using BuildQuery.WebApp.Models;

    //[Route("api/[controller]")]
    [Authorize]
    public class TfsApiController : ApiController
    {
        private IMainModelManager _manager;

        public TfsApiController(IMainModelManager manager)
        {
            _manager = manager;
        }
        // GET: api/values
        [HttpGet]
        public MainModel Get()
        {
            return _manager.MainModel;
        }

        [HttpGet]
        [Route("api/GetErrorsCsv")]
        public HttpResponseMessage GetErrorsCsv()
        {
            if (_manager.MainModel != null)
            {
                string fileName = "FailedTests" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".csv";

                
                var failedTests =
                    _manager.MainModel.KeyBuildList.SelectMany(x => x.TestRunList.SelectMany(y => y.FailedTestList))
                        .ToList();
                var failedTestCsvBuilder = new StringBuilder();
                failedTests.ForEach(
                    x =>
                    {
                        failedTestCsvBuilder.Append(x.BuildName);
                        failedTestCsvBuilder.Append(',');
                        failedTestCsvBuilder.Append(x.TestRunName);
                        failedTestCsvBuilder.Append(',');
                        failedTestCsvBuilder.Append(x.Name);
                        failedTestCsvBuilder.Append(',');
                        failedTestCsvBuilder.Append('"');
                        failedTestCsvBuilder.Append(x.ErrorMessage.Replace(',', '|').Replace('"','\''));
                        failedTestCsvBuilder.Append('"');
                        failedTestCsvBuilder.Append(Environment.NewLine);
                    });
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var content = Encoding.UTF8.GetBytes(failedTestCsvBuilder.ToString());
                response.Content = new ByteArrayContent(content);
                response.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = fileName;

                return response;
            }
            else
                return null;
        }
    }
}