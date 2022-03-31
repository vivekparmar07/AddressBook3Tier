<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
   
    <div class="row">
        <div class="col-md-12 table-responsive">
            <h1>City List</h1>
            <div class="alert alert-success" id="divMessage" runat="server" visible="false">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="justify-content-center">
                <asp:GridView runat="server" AutoGenerateColumns="false" ID="gvCity" CssClass="tabel table-responsive-md" Width="1300px" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="PinCode" HeaderText="Pincode" />
                        <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/City/CityAddEdit.aspx?CityID=" +Eval("CityID").ToString().Trim() %>' runat="server"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ToolTip="Delete Record" CssClass="btn btn-danger btn-sm" 
                                    OnClientClick="javascript:return confirm('Are you Sure wnat to delete Record ?');"
                                    CommandName="DeleteRecord" CommandArgument='<%#Eval("CityID") %>' Text="Delete"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <asp:HyperLink runat="server" ID="hlAddNewCity" Text="Add new" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-info btn-sm"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

