<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Panacea.Events.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p class="text-danger">
        <br />
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <p class="text-success">
        <br />
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Event Registration</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtArrivalDate" CssClass="col-md-2 control-label">Arrival Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtArrivalDate" class="form-control" ClientIDMode="Static" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtArrivalDate"
                    CssClass="text-danger" ErrorMessage="The arrival date field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlCountries" CssClass="col-md-2 control-label">Country</asp:Label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlCountries" CssClass="form-control">
                    <asp:ListItem Value="" Text="<Select Country>"></asp:ListItem>
                    <asp:ListItem Value="UK" Text="UK"></asp:ListItem>
                    <asp:ListItem Value="Lebanon" Text="Lebanon"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCountries"
                    CssClass="text-danger" ErrorMessage="The country field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlEvents" CssClass="col-md-2 control-label">Event</asp:Label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlEvents" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEvents"
                    CssClass="text-danger" ErrorMessage="The Event field is required." />
            </div>
        </div>




        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Register_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

    <link href="Content/jquery.datetimepicker.css" type="text/css" rel="Stylesheet" />
    <script src="Scripts/jquery.datetimepicker.full.min.js"></script>

    <script>
        var startDateTextBox = $('#txtArrivalDate');

        startDateTextBox.datetimepicker({
            format: 'd/m/Y H:i',

            formatDate: 'd/m/y',

            onShow: function (ct) {
                this.setOptions({
                    minDate: new Date()
                })
            }
        });

    </script>
</asp:Content>
