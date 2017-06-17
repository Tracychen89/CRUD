<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPageTemplate.aspx.cs" Inherits="aspdotnet_webform_template.AjaxPageTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajax Page Template</title>
    <script src="/js/jquery-3.1.0.js"></script>

    <script>
        function showAjaxContent() {
            $.ajax(
                {
                    method: "POST",
                    url: "AjaxPageTemplate.aspx?AjaxRequest=true",
                    datatype: "html"
                }).done(
                function (returnedHtml) {
                    var neededHtml = $($.parseHTML(returnedHtml)).find('#contentAjax')[0];
                    $('#contentAjax').replaceWith(neededHtml);
                }
                ).fail(function () {
                    alert('ERROR: ajax request failed.');
                });
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>this is a test line 1</p>
            <p>this is a test line 2</p>
            <div>
                <input id="input1" type="button" name="input1" value="input1value" title="ajax request" onclick="showAjaxContent(); return false;" />
            </div>
            <div id="contentAjax" runat="server"></div>
        </div>
    </form>
</body>
</html>
