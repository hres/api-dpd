<!DOCTYPE html>
<%@ taglib uri="/WEB-INF/struts-html.tld" prefix="html"%>
<%@ taglib uri="/WEB-INF/struts-bean.tld" prefix="bean"%>
<%@ taglib uri="/WEB-INF/struts-logic.tld" prefix="logic"%>

<bean:define id="applicationLang">
	<bean:message bundle="clfRes" key="label.app.lang" />
</bean:define>

<!--[if lt IE 9]>
<html class="no-js lt-ie9" lang="en" dir="ltr">
<![endif]-->

<!--[if gt IE 8]><!-->
<html class="no-js" lang="en" dir="ltr">
<!--<![endif]-->

	<head>
		<meta charset="utf-8">
		<!-- Web Experience Toolkit (WET) / Boite a  outils de l'expérience Web (BOEW) wet-boew.github.io/wet-boew/License-en.html / wet-boew.github.io/wet-boew/Licence-fr.html -->
		<title><bean:message key="label.timeout.title" /></title>
		
		<!-- Meta data -->
		<meta content="width=device-width,initial-scale=1" name="viewport">
		<meta name="description" content="<bean:message bundle="clfRes" key="meta_description" />">
		<meta name="dcterms.creator" content="<bean:message bundle="clfRes" key="meta_creator" />">
		<meta name="dcterms.title" content="<bean:message bundle="clfRes" key="meta_title" />">
		<meta name="dcterms.issued" title="W3CDTF" content="<bean:message bundle="clfRes" key="dcterms_issued" />">
		<meta name="dcterms.modified" title="W3CDTF" content="<bean:message bundle="clfRes" key="dcterms_modified" />">
		<meta name="dcterms.subject" content="<bean:message bundle="clfRes" key="meta_subject" />">
		<meta name="dcterms.language" title="ISO639-2" content="<bean:message bundle="clfRes" key="meta_language" />">
		<!-- Meta data -->
		
		<!--[if gte IE 9 | !IE ]><!-->
		<link href="assets/favicon.ico" rel="icon" type="image/x-icon">
		<link rel="stylesheet" href="css/wet-boew.min.css">
		<link rel="stylesheet" href="css/theme.min.css">
		<!--<![endif]-->
		
		<!--[if lt IE 9]>
			<link href="assets/favicon.ico" rel="shortcut icon" />
			<link rel="stylesheet" href="css/ie8-wet-boew.min.css" />
			<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
			<script src="js/ie8-wet-boew.min.js"></script>
			<![endif]-->
		<script src="js/jquery-2.1.1.min.js"></script>
		
		<!-- Only for developpement, delete for production -->
		<link rel="stylesheet" href="css/custom.css" />
		
		<noscript>
			<link rel="stylesheet" href="css/noscript.min.css" />
		</noscript>
	</head>

	<body vocab="http://schema.org/" typeof="WebPage">
		<header role="banner">
			<div id="wb-bnr" class="container">
				<div class="row">
					<div class="brand col-xs-8 col-sm-9 col-md-6">
						<object type="image/svg+xml" tabindex="-1" data="<bean:message key='label.timeout.image.address' />" id="canadaSVG"> </object>
					</div>
				</div>
			</div>
		</header>
	
		<main role="main" property="mainContentOfPage" class="container">
			<div class="row">
				<div class="col-lg-12 col-md-12 col-sm-12 text-center">
					<h1><bean:message key="label.timeout.title" /></h1>
				</div>
			</div><br>

			<div class="row">
				<div class="col-lg-6 col-md-6 col-sm-12 text-center">
					<p><bean:message key="label.timeout.message" /></p>
					<p><bean:message key="label.timeout.amount" /></p>
					<p><bean:message key="label.timeout.action" /></p><br>
					<logic:equal name="applicationLang" value="en">
						<p><html:link action="/start-debuter.do?lang=en"><bean:message key="label.timeout.link" /></html:link></p>
					</logic:equal>
					<logic:equal name="applicationLang" value="fr">
						<p><html:link action="/start-debuter.do?lang=fr"><bean:message key="label.timeout.link" /></html:link></p>
					</logic:equal>
				</div>
				<div class="col-lg-6 col-md-6 col-sm-12 text-center" lang="<bean:message key='label.timeout.opposite.language' />">
					<p><bean:message key="label.timeout.opposite.message" /></p>
					<p><bean:message key="label.timeout.opposite.amount" /></p>
					<p><bean:message key="label.timeout.opposite.action" /></p><br>
					<logic:equal name="applicationLang" value="fr">
						<p><html:link action="/start-debuter.do?lang=en"><bean:message key="label.timeout.opposite.link" /></html:link></p>
					</logic:equal>
					<logic:equal name="applicationLang" value="en">
						<p><html:link action="/start-debuter.do?lang=fr"><bean:message key="label.timeout.opposite.link" /></html:link></p>
					</logic:equal>
				</div>
			</div>
		</main><br><br>

		<footer role="contentinfo" id="wb-info" class=" mrgn-tp-md">
			<div class="brand">
				<div class="container">
					<div class="row">
						<div class="col-xs-2 col-xs-offset-5 col-md-3 col-md-offset-7 text-right">
							<object type="image/svg+xml" tabindex="-1" role="img" data="<bean:message key='label.timeout.footer.image.address' />" aria-label="<bean:message key='label.timeout.footer.image' />"></object>
						</div>
					</div>
				</div>
			</div>
		
			<!--[if gte IE 9 | !IE ]><!-->
			<script src="js/wet-boew.min.js"></script>
			<script src="js/theme.min.js"></script>
			<!--<![endif]-->
			<!--[if lt IE 9]>
			<script src="js/ie8-wet-boew2.min.js"></script>
			<![endif]-->
		</footer>

	</body>
</html>