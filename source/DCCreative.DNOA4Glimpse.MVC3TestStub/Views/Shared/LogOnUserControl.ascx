<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <strong><%: Page.User.Identity.Name %></strong>!
        [ <%: Html.ActionLink("Log Off", "Logout", "User") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Log On", "Login", "User") %> ]
<%
    }
%>
