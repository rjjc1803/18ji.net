﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoveExam.MVC.Base
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public abstract class BaseController : Controller
    {
        protected new JsonResult Json(object data)
        {
            return Json(data, JsonRequestBehavior.DenyGet);
        }


        /// <summary>
        /// 设置cookie值，默认3天过期
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void AddCookie(string name, string value)
        {
            AddCookie(name, value, null);
        }

        /// <summary>
        /// 设置cookie值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="expiresTime"></param>
        protected void AddCookie(string name, string value, DateTime? expiresTime)
        {
            HttpCookie cookie = new HttpCookie(name, value);
            // 如没有传参则默认3天过期
            cookie.Expires = expiresTime.GetValueOrDefault(DateTime.Now.AddDays(3));

            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string GetCookie(string name)
        {
            return Request.Cookies[name].Value;
        }

        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="name"></param>
        protected void RemoveCookie(string name)
        {
            if (Request.Cookies[name] != null)
            {
                Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }

        /// <summary>
        /// 移除所有cookie
        /// </summary>
        protected void RemoveAllCookie()
        {
            string[] cookieArray = Request.Cookies.AllKeys;
            foreach (var item in cookieArray)
            {
                Response.Cookies[item].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}