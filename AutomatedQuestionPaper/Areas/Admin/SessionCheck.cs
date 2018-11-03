﻿using System.Web.Mvc;

namespace AutomatedQuestionPaper.Areas.Admin
{
    /// <inheritdoc />
    /// <summary>
    ///     Will check for session of login functionality. Should be apply on controller
    /// </summary>
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Get the session value of current HTTP Context
            var session = filterContext.HttpContext.Session;


            // Check for Username Key value in Session
            // If its null the redirect request to Account Controller in Index action
            if (session["Username"] == null)
            {
                var uriHelper = new UrlHelper(filterContext.RequestContext);
                var redirectUrl = uriHelper.Action("Index", "Account", new {area = ""});
                filterContext.Controller.TempData["SessionErrorMessage"] = "Please log in to your account first";
                filterContext.Result = new RedirectResult(redirectUrl);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}