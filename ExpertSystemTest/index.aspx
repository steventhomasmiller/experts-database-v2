<%@ Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ExpertSystemTest.index" %>

<asp:Content ID="Content1" contentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" contentPlaceHolderID="ContentPlaceholder1" Runat="Server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <asp:ListView ID="ListView1" runat="Server">
        <ItemTemplate>

           <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 program-block">
                        <a href="<%#Eval("FS_URL")%>">
                            <div><img src="<%#Eval("Img_url") %>" alt="Photo of "<%# Eval("name") %>></div>
                            <div class="program-name">
                                <div class="program-title"><%# Eval("name") %></div>
                                <div class="program-sub-description"><%# Eval("College") %></div>
                                <br />
                                    <p><strong>Department:</strong><br/><%# Eval("Dept") %></p>
                                    <p class="specialization"><strong>Specialization:</strong><br/><%# Eval("Specialization") %></p>
                            </div>
                        </a>
                    </div>
            
                        
       
        </ItemTemplate>
    </asp:ListView>
</asp:Content>


