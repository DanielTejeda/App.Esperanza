using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Esperanza.UI.MVC.Hubs
{
    public class AgenciaHub : Hub
    {
        static List<string> AgenciaIds = new List<string>();
        static List<string> UserIds = new List<string>();
        static List<string> UserNames = new List<string>();


        public void AddAgenciaId(string idAgencia, string userName, string userId) //Este método será consumido por el Cliente
        {
            if (!AgenciaIds.Contains(idAgencia))
            {
                AgenciaIds.Add(idAgencia);
                var index = AgenciaIds.IndexOf(idAgencia);
                UserIds.Insert(index, userId);
                UserNames.Insert(index, userName);
            }
            Clients.All.agenciaStatus(AgenciaIds, UserIds, UserNames);
        }

        public void RemoveAgenciaId(string idAgencia)
        {
            if (AgenciaIds.Contains(idAgencia))
            {
                var index = AgenciaIds.IndexOf(idAgencia);
                AgenciaIds.Remove(idAgencia);
                UserIds.RemoveAt(index);
                UserNames.RemoveAt(index);
            }
            Clients.All.agenciaStatus(AgenciaIds, UserIds, UserNames);
        }

        public void AlertUpdate()
        {
            Clients.All.updateListTable();
        }

        public void Message(string message)
        {
            Clients.All.getMessage(message);
        }
    }
}