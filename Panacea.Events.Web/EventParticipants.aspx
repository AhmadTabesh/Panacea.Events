<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventParticipants.aspx.cs" Inherits="Panacea.Events.Web.EventParticipants" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p class="text-danger">
        <br />
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Event Participants</h4>
        <hr />


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlEvents" CssClass="col-md-2 control-label">Event</asp:Label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlEvents" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEvents"
                    CssClass="text-danger" ErrorMessage="The Event field is required." />
            </div>
        </div>

        

       <%-- <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="ViewParticipants_Click" Text="View Participants" CssClass="btn btn-default" />
            </div>
        </div>--%>

        <div class="row">
            <div class="col-lg-12 ">
                <div class="table-responsive">
                    <asp:GridView ID="gvParticipants" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="There are no data records to display." AllowSorting="true" AllowPaging="false" OnSorting="gvParticipants_Sorting">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <asp:BoundField DataField="ArrivalDate" HeaderText="Arrival Date" SortExpression="ArrivalDate" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <asp:BoundField DataField="RegistrationDate" HeaderText="Registration Date" SortExpression="RegistrationDate" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <%--<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
