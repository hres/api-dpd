using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoC.WebTemplate;

namespace MvcApplication1.Controllers
{
    public class HomeController : GoC.WebTemplate.WebTemplateBaseController
    {
        public ActionResult IndexEN()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Drug Product Database";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Drug Product Database", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-11");

            return View();
        }

        // Proper French translation still needed for view
        public ActionResult IndexFR()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Base de données sur les produits pharmaceutiques";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Accueil", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/fr", "Gouvernement ouvert", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/fr/dataset?q=DPD", "Données ouvertes", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Base de données sur les produits pharmaceutiques", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-11");

            return View();
        }

        //View Responsible for changing between the English and French PM
        public ActionResult LanguageControl()
        {
            // If pages other than Index are used this will need to be passed a parameter so that
            // it can change to the correct French/English version rather than just hardcoded
            if (Session["GoC.Template.Culture"].Equals("en-CA"))
            {
                Session["GoC.Template.Culture"] = "fr-CA";
                return Redirect("IndexFR");
            }
            else if (Session["GoC.Template.Culture"].Equals("fr-CA"))
            {
                Session["GoC.Template.Culture"] = "en-CA";
                return Redirect("IndexEN");
            }
            else //Default redirect to English Index
                return Redirect("IndexEn");
        }
    }
}
