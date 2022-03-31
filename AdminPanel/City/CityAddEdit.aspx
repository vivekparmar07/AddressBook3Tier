<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="alert alert-success" id="divMessage" runat="server" visible="false">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            
        </div>
    </div>

    <div class="col-md-6">
        <div class="row">
            <div class="col-md-4">
                <h5>State Id</h5>
            </div>
            <div class="col-md-8">
                <asp:DropDownList runat="server" ID="ddlStateId" CssClass="form-select"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStateID" runat="server" ErrorMessage="Select State" ControlToValidate="ddlStateId" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                
            </div>
        </div>
    </div>
    
    <div class="col-md-6">
        <div class="row">
            <div class="col-md-4">
                <h5>City Name</h5>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City Name" ControlToValidate="txtCityName" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        </div>
        <div class="col-md-4">
            
        </div>
        
    
        
    <div class="col-md-6">
        <div class="row">
            <div class="col-md-4">
                <h5>City Code</h5>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtPincode" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="row">
            <div class="col-md-4">
                <h5>STD Code</h5>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtStdCode" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success btn-sm" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>

