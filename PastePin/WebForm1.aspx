<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PastePin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <p>
             Skriv noe å trykk på knappen for å få en link å kopiere
        </p>

            <textarea id ="Msgarea" runat="server" class="auto-style3" cols="20" name="S1" rows="1"></textarea>
        </div>

        <p>
           <asp:Button ID="ButtonCreateQueryString" runat="server" Text="Get copy link" OnClick="ButtonCreateQueryString_Click" Height="43px" Width="109px" />
            
        </p>

        <style>
    body {background-color: darkseagreen;} 
            .auto-style3 {
                width: 947px;
                height: 370px;
            }
   </style>

        
        



        
        


    </form>
    
</body>
</html>
