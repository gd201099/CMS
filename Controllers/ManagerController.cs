using CMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS.Models;



namespace CMS.Controllers
{
    public class ManagerController : ApiController
    {
        // GET Method for Manager table
        public HttpResponseMessage Get()
        {
            string query = @"
                    select HrId, HrFirstName, HrLastName, HrPhone, HrEmail, Username, Password from
                    dbo.Manager
                    ";
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMSapp"].ConnectionString))
            using(var cmd= new SqlCommand(query,con))

            using(var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        // POST Method for Manager
        public string Post(Manager hr)
        {
            try
            {
                string query = @"
                                 insert into dbo.Manager values
                                 ('" +hr.HrFirstName+ @"',
                                 '" +hr.HrLastName+ @"',
                                 '" +hr.HrPhone+ @"',
                                 '" +hr.HrEmail+ @"',
                                 '" +hr.Username+ @"',
                                 '" +hr.Password+ @"')
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
            catch(Exception)
            {
                return "Failed to ADD!!";
            }
        }

        // PUT Method for Manager
        public string Put(Manager hr)
        {
            try
            {
                string query = @"
                                 update dbo.Manager set
                                  HrFirstName= '" +hr.HrFirstName+ @"'
                                 ,HrLastName= '" +hr.HrLastName+ @"'
                                 ,HrPhone= '" +hr.HrPhone+ @"'
                                 ,HrEmail= '" +hr.HrEmail+ @"'
                                 ,Username= '" +hr.Username+ @"'
                                 ,Password= '" +hr.Password+ @"'
                                 where HrId= " +hr.HrId+ @"
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

        // DELETE Method for Manager
        public string Delete(int id)
        {
            try
            {
                string query = @"
                                 delete from dbo.Manager 
                                 where HrId= " +id+ @"
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


    }
}
