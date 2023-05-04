﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elanat
{
	public class FootPrintClass
	{
        public void Add(string Event, string Value)
        {
            if(!StaticObject.RoleSubmitFootPrintCheck())
                return;

            if (string.IsNullOrEmpty(Value))
                Value = "_";

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            string UserId = ccoc.UserId;
            string Path = HttpContext.Current.Request.Url.AbsolutePath;
            string Ip = Security.GetUserIp();
            string Date = DateAndTime.GetDate("yyyy/MM/dd");
            string Time = DateAndTime.GetTime("HH:mm:ss");
            
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_foot_print", new List<string>() { "@user_id", "@event", "@value", "@path", "@date", "@time", "@ip_address" }, new List<string>() { UserId, Event, Value, Path, Date, Time, Ip });
        }
	}
}