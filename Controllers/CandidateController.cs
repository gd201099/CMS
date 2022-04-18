using CMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CMS.Controllers
{
    public class CandidateController : ApiController
    {
        // GET Method for Candidate table
        public HttpResponseMessage Get()
        {
            string query = @"
                    select CandidateId, FirstName, LastName, Phone, Email, Source, Status, Resume from
                    dbo.Candidate
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSapp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))

            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        // POST Method for Candidate
        public string Post(Candidate ca)
        {
            try
            {
              string query = @"
                                 insert into dbo.Candidate values
                                 ('" + ca.FirstName + @"'
                                 ,'" + ca.LastName + @"'
                                 ,'" + ca.Phone + @"'
                                 ,'" + ca.Email + @"'
                                 ,'" + ca.Source + @"'
                                 ,'" + ca.Status + @"'
                                 ,'" + ca.Resume + @"')
                                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSapp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }
            catch (Exception)
            {
                return ("Failed to Add!!");
            }
        }

        // PUT Method for Candidate
        public string Put(Candidate ca)
        {
            try
            {
                string query = @"
                                 update dbo.Candidate set
                                  FirstName= '" + ca.FirstName + @"'
                                 ,LastName= '" + ca.LastName + @"'
                                 ,Phone= '" + ca.Phone + @"'
                                 ,Email= '" + ca.Email + @"'
                                 ,Source= '" + ca.Source + @"'
                                 ,Status= '" + ca.Status + @"'
                                 ,Resume= '" + ca.Resume + @"'
                                 where CandidateId= " + ca.CandidateId + @"
                                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSapp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!";
            }
            catch (Exception)

            {
                return " Failed to Update!!";
            }
        }

        // DELETE Method for Candidate
        public string Delete(int id)
        {
            try
            {
                string query = @"
                                 delete from dbo.Candidate
                                 where CandidateId= " + id + @"
                                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSapp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Delete!!";
            }
        }

        //To save the candidate resumes
        [Route("api/Candidate/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/CandidateResumes/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;

            }
            catch (Exception)
            {

                return "anonymous.pdf";
            }
        }

    }
}
