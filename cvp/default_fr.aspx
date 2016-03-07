﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html><!--[if lt IE 9]><html class="no-js lt-ie9" lang="fr" dir="ltr"><![endif]--><!--[if gt IE 8]><!-->
<html class="no-js" lang="fr" dir="ltr">
<!--<![endif]-->
<head>
<meta charset="utf-8">
<!-- Web Experience Toolkit (WET) / Boîte à outils de l'expérience Web (BOEW)
wet-boew.github.io/wet-boew/License-en.html / wet-boew.github.io/wet-boew/Licence-fr.html -->
<title>Inspections des essais cliniques - recherche d'essai clinique</title>
<meta content="width=device-width,initial-scale=1" name="viewport">
<!-- Meta data -->
<meta name="description" content="La Boîte à outils de l’expérience Web (BOEW) rassemble différents composants réutilisables et prêts-à-utiliser pour la conception et la mise à jour de sites Web innovateurs qui sont à la fois accessibles, conviviaux et interopérables. Tous ces composants réutilisables sont des logiciels libres mis à la disposition des ministères et des collectivités Web externes.">
<!-- Meta data-->
<!--[if gte IE 9 | !IE ]><!-->
<link href="./wet/assets/favicon.ico" rel="icon" type="image/x-icon">
<link rel="stylesheet" href="./wet/css/wet-boew.min.css">
<!--<![endif]-->
<link rel="stylesheet" href="./wet/css/theme.min.css">
<!--[if lt IE 9]>
<link href="./wet/assets/favicon.ico" rel="shortcut icon" />

<link rel="stylesheet" href="./wet/css/ie8-wet-boew.min.css" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="./wet/js/ie8-wet-boew.min.js"></script>
<![endif]-->
<!--[if lte IE 9]>


<![endif]-->
<link rel="stylesheet" href="inspections.css">
<noscript><link rel="stylesheet" href="./wet/css/noscript.min.css" /></noscript>
<!-- Google Tag Manager DO NOT REMOVE OR MODIFY - NE PAS SUPPRIMER OU MODIFIER -->
<script>dataLayer1 = [];</script>
<!-- End Google Tag Manager -->
</head>
<body vocab="http://schema.org/" typeof="WebPage">
<!-- Google Tag Manager DO NOT REMOVE OR MODIFY - NE PAS SUPPRIMER OU MODIFIER -->
<noscript><iframe title="Google Tag Manager" src="//www.googletagmanager.com/ns.html?id=GTM-TLGQ9K" height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start': new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0], j=d.createElement(s),dl=l!='dataLayer1'?'&l='+l:'';j.async=true;j.src='//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);})(window,document,'script','dataLayer1','GTM-TLGQ9K');</script>
<!-- End Google Tag Manager -->
<ul id="wb-tphp">
<li class="wb-slc">
<a class="wb-sl" href="#wb-cont">Passer au contenu principal</a>
</li>
<li class="wb-slc visible-sm visible-md visible-lg">
<a class="wb-sl" href="#wb-info">Passer à «&#160;À propos de ce site&#160;»</a>
</li>
</ul>
<header role="banner">
<div id="wb-bnr" class="container">
<section id="wb-lng" class="visible-md visible-lg text-right">
<h2 class="wb-inv">Sélection de la langue</h2>
<div class="row">
<div class="col-md-12">
<ul class="list-inline margin-bottom-none">
<li><a lang="en" href="default.aspx">English</a></li>
</ul>
</div>
</div>
</section>
<div class="row">
	<div class="brand col-xs-8 col-sm-9 col-md-6">
		<a href="http://www.canada.ca/fr/index.html"><object type="image/svg+xml" tabindex="-1" data="http://canadiensensante.gc.ca/distro/4.0.18/GCWeb/assets/sig-blk-fr.svg"></object><span class="wb-inv"> Gouvernement du Canada</span></a>
	</div>
	<section class="wb-mb-links col-xs-4 col-sm-3 visible-sm visible-xs" id="wb-glb-mn">
		<h2>Recherche et menus</h2>
		<ul class="list-inline text-right chvrn">
			<li><a href="#mb-pnl" title="Recherche et menus" aria-controls="mb-pnl" class="overlay-lnk" role="button"><span class="glyphicon glyphicon-search"><span class="glyphicon glyphicon-th-list"><span class="wb-inv">Recherche et menus</span></span></span></a></li>
		</ul>
		<div id="mb-pnl"></div>
	</section>
	<section id="wb-srch" class="col-xs-6 text-right visible-md visible-lg">
		<h2 class="wb-inv">Recherche</h2>
		<form action="http://search-recherche.gc.ca/rGs/s_r" method="get" name="cse-search-box" role="search" class="form-inline">
			<script type="text/javascript" src="https://www.google.com/jsapi"></script>
			<script type="text/javascript">var autoCompletionOptions = { 'validLanguages' : 'fr', };
					google.load( 'search', '1');
					google.setOnLoadCallback( function() {google.search.CustomSearchControl.attachAutoCompletionWithOptions( '008724028898028201144:knjjdikrhq0', document.getElementById( 'wb-srch-q' ), 'cse-search-box', autoCompletionOptions );});
					google.setOnLoadCallback( function() {setTimeout( function(){google.search.CustomSearchControl.attachAutoCompletionWithOptions( '008724028898028201144:knjjdikrhq0', document.getElementById( 'wb-srch-q-imprt' ), 'cse-search-box',autoCompletionOptions );}, 2000);});</script>
			<div class="form-group">
				<label for="wb-srch-q" class="wb-inv">Recherchez le site Web</label>
				<input name="cdn" value="canada" type="hidden"/>
				<input name="st" value="s" type="hidden"/>
				<input name="num" value="10" type="hidden"/>
				<input name="langs" value="fra" type="hidden"/>
				<input name="st1rt" value="0" type="hidden">
				<input name="s5bm3ts21rch" value="x" type="hidden"/>
				<input id="wb-srch-q" class="wb-srch-q form-control" name="q" type="search" value="" size="27" maxlength="150" placeholder="Rechercher dans Canada.ca"/>
			</div>
			<div class="form-group submit">
				<button type="submit" id="wb-srch-sub" class="btn btn-primary btn-small" name="wb-srch-sub"><span class="glyphicon-search glyphicon"></span><span class="wb-inv">Recherche</span></button>
			</div>
		</form> 
	</section>
</div>
</div>
<nav role="navigation" id="wb-sm" class="wb-menu visible-md visible-lg" data-trgt="mb-pnl" data-ajax-replace="http://travel.gc.ca/gcweb-cdn-host/sitemenu/sitemenu-fr.html" typeof="SiteNavigationElement">
<h2 class="wb-inv">Menu des sujets</h2>
<div class="container nvbar">
<div class="row">
<ul class="list-inline menu">
<li><a href="http://www.edsc.gc.ca/fr/emplois/index.page">Emplois</a></li>
<li><a href="http://www.cic.gc.ca/francais/index.asp">Immigration</a></li>
<li><a href="http://voyage.gc.ca/">Voyage</a></li>
<li><a href="http://www.canada.ca/fr/services/entreprises/index.html">Entreprises</a></li>
<li><a href="http://www.canada.ca/fr/services/prestations/index.html">Prestations</a></li>
<li><a href="http://canadiensensante.gc.ca/index-fra.php">Santé</a></li>
<li><a href="http://www.canada.ca/fr/services/impots/index.html">Impôts</a></li>
<li><a href="http://www.canada.ca/fr/services/index.html">Autres services</a></li>
</ul>
</div>
</div>
</nav>
<nav role="navigation" id="wb-bc" class="" property="breadcrumb">
<h2 class="wb-inv">Vous êtes ici :</h2>
<div class="container">
<div class="row">
<ol class="breadcrumb">
    <li><a href="http://canada.ca/fr/index.html">Accueil</a></li>
    <li><a href="http://open.canada.ca/fr">Gouvernement ouvert</a></li>
    <li><a href="http://ouvert.canada.ca/data/fr/dataset/9cbaef00-b52c-4a70-9fed-d9aa8263ab74">Données ouvertes</a></li>
</ol>
</div>
</div>
</nav>
</header>
    <main role="main" property="mainContentOfPage" class="container">
        <div id="body">
            <section class="featured">
                <div class="content-wrapper">
                    <hgroup class="title">
                        <h1>Base de données en ligne des effets indésirables de Canada Vigilance - APIs</h1>
                    </hgroup>
                    <table class="wb-tables table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>
                                    Requête par :
                                </th>
                                <th scope=colgroup colspan=2>
                                    Format :
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Produits pharmaceutiques :</td>
                                <td> <a class="btn btn-default" href="/api/drugproduct/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/drugproduct/?type=xml">XML</a></td>
                            </tr>
                            <tr>
                                <td>Produits pharmaceutiques par id = 100 :</td>
                                <td> <a class="btn btn-default" href="/api/drugproduct/100/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/drugproduct/100/?type=xml">XML</a></td>
                            </tr>
                            <tr>
                                <td>Ingredient de produits pharmaceutiques :</td>
                                <td><a class="btn btn-default" href="/api/drugproductingredient/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/drugproductingredient/?type=xml">XML</a></td>
                            </tr>
                            <tr>
                                <td>Ingredient de produits pharmaceutiques par id = 4049:</td>
                                <td><a class="btn btn-default" href="/api/drugproductingredient/4049/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/drugproductingredient/4049/?type=xml">XML</a></td>
                            </tr>
                            <tr>
                                <td>Rapport :</td>
                                <td><a class="btn btn-default" href="/api/report/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/report/?type=xml">XML</a></td>
                            </tr>
                            <tr>
                                <td>Rapport par id = 1:</td>
                                <td><a class="btn btn-default" href="/api/report/1/?type=json">Json</a></td>
                                <td><a class="btn btn-default" href="/api/report/1/?type=xml">XML</a></td>
                            </tr>
                              </tbody>
                    </table>

                </div>
            </section>
        </div>
       <div class="row pagedetails">
			<div class="col-sm-5 col-xs-12 datemod">
				<dl id="wb-dtmd">
				<dt>Date de modification&#160;:&#32;</dt>
				<dd><time property="dateModified">2016-01-12</time></dd>
				</dl>
			</div>
			<div class="clear visible-xs"></div>
			<div class="col-sm-4 col-xs-6">
				<a href="http://www.canada.ca/fr/contact/retroaction.html" class="btn btn-default"><span class="glyphicon glyphicon-comment mrgn-rght-sm"></span>Rétroaction<span class="wb-inv"> sur ce site Web</span></a>
			</div>
			<div class="col-sm-3 col-xs-6 text-right">
				<div class="wb-share" data-wb-share='{"lnkClass": "btn btn-default"}'></div>
			</div>
			<div class="clear visible-xs"></div>
		</div>
    </main>
    <aside class="gc-nttvs container">
        <h2>Activités et initiatives du gouvernement du Canada</h2>
        <div id="gcwb_prts" class="wb-eqht row" data-ajax-replace="//cdn.canada.ca/gcweb-cdn-live/features/features-fr.html"><p class="mrgn-lft-md"><a href="http://www.canada.ca/activites.html">Accédez aux activités et initiatives du gouvernement du Canada</a></p> </div>
    </aside>

<footer role="contentinfo" id="wb-info">
<nav role="navigation" class="container visible-sm visible-md visible-lg wb-navcurr">
<h2 class="wb-inv">À propos de ce site</h2>
<div class="row">
<div class="col-sm-3 col-lg-3">
<section>
<h3>Coordonnées</h3>
<!--Start Healthy Canadians contact info-->
<ul class="list-unstyled">
<li><a href="http://canadiensensante.gc.ca/report-signalez/index-fra.php">Signaler un rapport d'incident</a></li>
<li><a href="http://canadiensensante.gc.ca/say-exprimez/index-fra.php">Participation du public</a></li>
<li><a href="http://canadiensensante.gc.ca/contact-contactez/index-fra.php">Renseignements généraux</a></li>
<li><a href="http://canadiensensante.gc.ca/connect-connectez/index-fra.php">Restez branché</a></li>
</ul>
<!--End Healthy Canadians contact info-->
</section>
<section>
<h3>Nouvelles</h3>
<ul class="list-unstyled">
<li><a href="http://nouvelles.gc.ca/web/index-fr.do">Salle de presse</a></li>
<li><a href="http://nouvelles.gc.ca/web/nwsprdct-fr.do?mthd=tp&amp;crtr.tp1D=1">Communiqués de presse</a></li>
<li><a href="http://nouvelles.gc.ca/web/nwsprdct-fr.do?mthd=tp&amp;crtr.tp1D=3">Avis aux médias</a></li>
<li><a href="http://nouvelles.gc.ca/web/nwsprdct-fr.do?mthd=tp&amp;crtr.tp1D=970">Discours</a></li>
<li><a href="http://nouvelles.gc.ca/web/nwsprdct-fr.do?mthd=tp&amp;crtr.tp1D=980">Déclarations</a></li>
</ul>
</section>
</div>
<section class="col-sm-3 col-lg-3">
<h3>Gouvernement</h3>
<ul class="list-unstyled">
<li><a href="http://www.canada.ca/fr/gouv/systeme/index.html">Comment le gouvernement fonctionne</a></li>
<li><a href="http://www.canada.ca/fr/gouv/min/index.html">Ministères et organismes</a></li>
<li><a href="http://pm.gc.ca/fra">Premier ministre</a></li>
<li><a href="http://www.canada.ca/fr/gouv/ministres/index.html">Ministres</a></li>
<li><a href="http://www.canada.ca/fr/gouv/politique/index.html">Politiques, règlements et lois</a></li>
<li><a href="http://www.canada.ca/fr/gouv/bibliotheques/index.html">Bibliothèques</a></li>
<li><a href="http://www.canada.ca/fr/gouv/publications/index.html">Publications</a></li>
<li><a href="http://www.canada.ca/fr/gouv/statistiques/index.html">Statistiques et données</a></li>
<li><a href="http://www.canada.ca/fr/nouveausite.html">À propos de Canada.ca</a></li>
</ul>
</section>
<section class="col-sm-3 col-lg-3 brdr-lft">
<h3>Transparence</h3>
<ul class="list-unstyled">
<li><a href="http://www.canada.ca/fr/transparence/rapports.html">Établissement de rapports à l'échelle du gouvernement</a></li>
<li><a href="http://ouvert.canada.ca/fr/">Gouvernement ouvert</a></li>
<li><a href="http://www.canada.ca/fr/transparence/divulgation.html">Divulgation proactive</a></li>
<li><a href="http://www.canada.ca/fr/transparence/avis.html">Avis</a></li>
<li><a href="http://www.canada.ca/fr/transparence/confidentialite.html">Confidentialité</a></li>
</ul>
</section>
<div class="col-sm-3 col-lg-3 brdr-lft">
<section>
<h3>Rétroaction</h3>
<p><a href="http://www.canada.ca/fr/contact/retroaction.html"><img src="./wet/assets/feedback.png" alt="Rétroaction sur ce site Web"></a></p>
</section>
<section>
<h3>Médias sociaux</h3>
<p><a href="http://www.canada.ca/fr/sociaux/index.html"><img src="./wet/assets/social.png" alt="Médias sociaux"></a></p>
</section>
<section>
<h3>Centre mobile</h3>
<p><a href="http://www.canada.ca/fr/mobile/index.html"><img src="./wet/assets/mobile.png" alt="Centre mobile"></a></p>
</section>
</div>
</div>
</nav>
<div class="brand">
<div class="container">
<div class="row">
<div class="col-xs-6 visible-sm visible-xs tofpg">
<a href="#wb-cont">Haut de la page <span class="glyphicon glyphicon-chevron-up"></span></a>
</div>
<div class="col-xs-6 col-md-12 text-right">
<object type="image/svg+xml" tabindex="-1" role="img" data="./wet/assets/wmms-blk.svg" aria-label="Symbole du gouvernement du Canada"></object>
</div>
</div>
</div>
</div>
</footer>
<!--[if gte IE 9 | !IE ]><!-->
<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script src="./wet/js/wet-boew.min.js"></script>
<!--<![endif]-->
<!--[if lt IE 9]>
<script src="./wet/js/ie8-wet-boew2.min.js"></script>
<![endif]-->
<script src="./wet/js/theme.min.js"></script>
<script src="./js/inspections.js"></script>

<!--[if lt IE 10 | !IE ]><!-->
<script src="./js/jquery.xdomainrequest.min.js"></script>
<!--<![endif]-->
    <!-- GA Code Start -->
    <script src="http://healthycanadians.gc.ca/alt/js/ga-addon.js" type="text/javascript"></script>
    <script>
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-21671527-4']);
  _gaq.push(['_gat._anonymizeIp']);
  _gaq.push(['_setDomainName', 'none']);
  _gaq.push(['_setAllowLinker', true]);
  _gaq.push(['_trackPageview']);
  _gaq.push(['_trackDownload']);	// Recently added
  _gaq.push(['_trackOutbound']);	// Recently added

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
    </script>
    <!-- GA Code Ends -->
    <!--Script-section-Start-->
    <script>
        $(".wb-frmvld").on("wb-ready.wb-frmvld", function (event) {
            var now = new Date();
            var day = (now.getDate() < 10 ? '0' : '') + now.getDate();
            var month = ((now.getMonth() + 1) < 10 ? '0' : '') + (now.getMonth() + 1);
            var year = now.getFullYear();
            var todayDate = year + "-" + month + "-" + day;

            $("#startDate").rules("add", {
                max: todayDate
            });    
        });
    </script>
<!--Script-section-End-->
</body>
</html>