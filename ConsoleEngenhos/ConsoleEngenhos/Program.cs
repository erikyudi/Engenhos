using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEngenhos;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;


namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShowWorkItemDetails().Wait();
        }
        

        static private async Task ShowWorkItemDetails()
        {

            try
            {

                Uri uri = new Uri(ConfigurationManager.AppSettings["uri"]);

                VssBasicCredential credentials = new VssBasicCredential("", ConfigurationManager.AppSettings["personalAccessToken"]);

                Int64? idWork = 0;
                using (var context1 = new WorkItemContext())
                {
                    if(context1.WorkItems.Count()>0)
                    idWork = context1.WorkItems.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                }
                Console.WriteLine("Montando consulta");
                string consulta = "Select * " +
                            "From WorkItems " +
                            "Where [System.TeamProject] = '" + ConfigurationManager.AppSettings["project"] + "' ";
                            //"and [id] < 10";

                //Adiciono condição para pegar do ultimo id incluido pra cima
                if (idWork > 0)
                {
                    consulta= consulta+"And [Id] > " + idWork;
                }
                
                Wiql wiql = new Wiql()
                {
                    Query = consulta

                };


                using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
                {
                    WorkItemQueryResult workItemQueryResult = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql);

                    if (workItemQueryResult.WorkItems.Count() != 0)
                    {
                        List<int> list = new List<int>();
                        foreach (var item in workItemQueryResult.WorkItems)
                        {
                            list.Add(item.Id);
                        }
                        int[] arr = list.ToArray();

                        string[] fields = new string[5];
                        fields[0] = "System.Id";
                        fields[1] = "System.Title";
                        fields[2] = "System.State";
                        fields[3] = "System.WorkItemType";
                        fields[4] = "System.CreatedDate";

                        var workItems = await workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf);

                        Console.WriteLine("Adicionando itens na tabela");
                        foreach (var workItem in workItems)
                        {
                            try
                            {
                                using (var context = new WorkItemContext())
                                {

                                    var work = new WorkItems()
                                    {
                                        Id = workItem.Id,
                                        Titulo = workItem.Fields["System.Title"].ToString(),
                                        Tipo = workItem.Fields["System.WorkItemType"].ToString(),
                                        DataCriacao = Convert.ToDateTime(workItem.Fields["System.CreatedDate"].ToString())
                                    };

                                    context.WorkItems.Add(work);
                                    context.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                        }
                        Console.ReadKey();
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}