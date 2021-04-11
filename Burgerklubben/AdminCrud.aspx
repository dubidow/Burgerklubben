<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCrud.aspx.cs" Inherits="Burgerklubben.AdminCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Burgerklubben</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous" />
    <link href="Content/css.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Amatic+SC:wght@400;700&display=swap" rel="stylesheet" />
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header start !-->

        <!--Bootstrap navbar customized in CSS!-->
        <nav class="navbar navbar-expand-sm navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="Frontpage.aspx">
                    <img src="images/logo.png" class="img-fluid" alt="logo" /></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
                    aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                    <div class="navbar-nav ms-auto">
                        <a class="nav-link" href="Menu.aspx">Menu</a>
                        <a class="nav-link" href="Info.aspx">Info</a>
                        <a class="nav-link" href="Login.aspx">Login</a>
                        <a class="nav-link" href="Checkout.aspx">
                            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="white" class="bi bi-basket3" viewBox="0 0 16 16">
                                <path d="M5.757 1.071a.5.5 0 0 1 .172.686L3.383 6h9.234L10.07 1.757a.5.5 0 1 1 .858-.514L13.783 6H15.5a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5H.5a.5.5 0 0 1-.5-.5v-1A.5.5 0 0 1 .5 6h1.717L5.07 1.243a.5.5 0 0 1 .686-.172zM3.394 15l-1.48-6h-.97l1.525 6.426a.75.75 0 0 0 .729.574h9.606a.75.75 0 0 0 .73-.574L15.056 9h-.972l-1.479 6h-9.21z" />
                            </svg></a>
                    </div>
                </div>
            </div>
        </nav>
        <!-- Header end !-->
        <!-- Content start !-->
        <div class="content">
            <!--Name of user and Logout button !-->
            <div class="UserInfo-Logout d-flex justify-content-end">
                <asp:Label ID="lblUserDetails" runat="server" Text="Label" ForeColor="White"></asp:Label>
                <br />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            </div>
            <!-- Admin menu start !-->
            <div class="container-admin">
                <h1 class="admincrud-headline">Admin CRUD</h1>

                <div class="row d-flex justify-content-center">
                    <!--Update info and update product start!-->
                    <div class="col-lg-5 d-flex justify-content-center selectSP">
                        <div>
                            <h2 class="adminh2">Ret data</h2>
                            <!-- Select box start!-->
                            <select class="selectspselector" runat="server" id="SPMenu">
                                <option value="Blank">Choose</option>
                                <option value="SP_InfoUpdateAboutUs">Info-About Us</option>
                                <option value="SP_InfoUpdateEmail">Info-Email</option>
                                <option value="SP_InfoUpdateOpeningHours">Info-Opening Hous</option>
                                <option value="SP_InfoUpdatePhone">Info-Phone</option>
                                <option value="SP_InfoUpdateStreetNameNumber">Info-StreetName and Number</option>
                                <option value="SP_InfoUpdateZipCode">Info-Zipcode</option>
                                <option value="SP_ProductUpdateImgPath">Product-Img Path</option>
                                <option value="SP_ProductUpdatePDescription">Product-Description</option>
                                <option value="SP_ProductUpdatePName">Product-Name</option>
                                <option value="SP_ProductUpdatePrice">Product-Price</option>
                                <option value="SP_ProductUpdatePType">Product-Type</option>
                                <option value="SP_ProductDeleteProduct">Product-Delete</option>
                            </select>
                            <!-- Select box end!-->
                            <!--Labels, textboxes and executebuttons!-->
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIdentifier" CssClass="setsplbl" runat="server" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIdentifier" CssClass="setsptxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Following Label and Textbox only visible when btnPickSP has been clicked !-->
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNewData" CssClass="setsplbl" runat="server" Text="Ny data" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNewData" CssClass="setsptxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnPickSP" runat="server" Text="Vælg" OnClick="btnPickSp_Click"></asp:Button>
                                        <asp:Button ID="btnExecuteSP" runat="server" Text="Udfør" OnClick="btnExecuteSP_Click"></asp:Button>
                                    </td>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lblTryCatchSP" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <!--Update info and update product end!-->
                    <div class="col-lg-2"></div>

                    <!--Set new product start!-->
                    <div class="col-lg-5 setProduct">
                        <div>
                            <%--  <h2>Opret produkt</h2>--%>
                            <table class="setproducttable">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPType" CssClass="setproductlbl" runat="server" Text="Produkt type" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPType" CssClass="setproducttxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName" CssClass="setproductlbl" runat="server" Text="Produkt navn" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPName" CssClass="setproducttxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPrice" CssClass="setproductlbl" runat="server" Text="Produkt pris" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrice" CssClass="setproducttxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPDescription" CssClass="setproductlbl" runat="server" Text="Produkt beskrivelse" ForeColor="White"></asp:Label>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPDescription" CssClass="setproducttxt" TextMode="multiline" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblImgPath" CssClass="setproductlbl" runat="server" Text="Billedesti til produkt foto" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtImgPath" CssClass="setproducttxt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSetProduct" runat="server" Text="Tilføj produkt" OnClick="btnSetProduct_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblTryCatchSet" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <!--Set new product end!-->
                </div>
            </div>
            <!-- Admin menu end !-->
        </div>

        <!-- Content end !-->

    </form>

    <!-- Bootstrap !-->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.6.0/dist/umd/popper.min.js" integrity="sha384-KsvD1yqQ1/1+IA7gi3P0tyJcT3vR+NdBTt13hSJ2lnve8agRGXTTyNaBYmCR/Nwi" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.min.js" integrity="sha384-nsg8ua9HAw1y0W1btsyWgBklPnCUAFLuTMS2G72MMONqmOymq585AcH49TLBQObG" crossorigin="anonymous"></script>
</body>
</html>

