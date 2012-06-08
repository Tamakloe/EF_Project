<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="content">
		<h2><%: ViewBag.Message %></h2>
		<p>
			Rate my Amenities is an enterprise application intended to provide users with a place to search <br />
			for and view amenities in their local area, rate the amenity and view other users ratings and comments.
		</p>
		<p>
			Users can search for amenities using a range of criteria including location, type of amenity and rating.
		</p>
		<p>
			Alternatively users can search within a selected radius.<br />
			This may be from a selected location or from a user’s current location, if GPS is available on the users device.
		</p>
	</div>
	

</asp:Content>
