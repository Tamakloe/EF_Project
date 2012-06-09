<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    
    <h3> Sources </h3>
	<p>Data for the site will be obtained from the following sources.</p>
	<ol>
		<li>Public data obtained from Fingal County Council <a href="http://data.fingal.ie/" target="_blank">Fingal Data</a>.</li>
		<li>An internal database that records the following information</li>
		<ul>
			<li>User details, used for login and authentication.</li>
			<li>Rating data.  This will include a rating number, category, comment, amenity id and user id.</li>
		</ul>
		<li>Data Mining of Twitter, Facebook, etc</li>
		<li>Data on the number of other users that searched and rated / commented on an amenity.</li>
	</ol>
	<h3>Security and Authentication</h3>
	<p>In order for users to rate an amenity and add/edit a comment, they must first login and be authenticated.<br />
	  (This is to ensure that each user only logs a single rating/comment per amenity and hence help ensure reliability of the data).
	</p>
	<p>To encourage users to create an account and leave rating and feedback users will be incentivised to create a login.
	</p>
	<p>
	  Users can also be authenticated using their Facebook, MS, etc. account (just a suggestion).
	</p>
	
</asp:Content>
