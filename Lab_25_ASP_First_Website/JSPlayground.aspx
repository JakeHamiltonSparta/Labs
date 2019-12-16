<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JSPlayground.aspx.cs" Inherits="Lab_25_ASP_First_Website.JSPlayground" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        var x = 0;

        function runSomeTestData()
        {
            x++;
            alert('The value of x is ' + x);
            var genius = confirm('are you a computer genius?');
            var name = prompt('OK then fine! Whats your name?');

            if (genius)
            {
                alert('Thanks, ' + name + ', I will come to you for advice!');
            }

            else
            {
                alert('OK, Ill go elsewhere with my issues');
            }
            console.log(genius)
            console.log(name)
        }
    </script>

    <button onclick="runSomeTestData()">Run some test data</button>

    <div id="test-data">

    </div>



</asp:Content>
