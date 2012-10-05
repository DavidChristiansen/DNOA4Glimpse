<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Members Only Area
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h1>Members Only Area </h1>
	<p>Congratulations, <b>
		<%=Session["FriendlyIdentifier"] %></b>. You have completed the OpenID login process.
	</p>
	<p>
		<%=Html.ActionLink("Logout", "logout") %>
	</p>

</asp:Content>
