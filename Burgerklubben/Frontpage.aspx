<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frontpage.aspx.cs" Inherits="Burgerklubben.Frontpage" %>

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
        <!-- Container start !-->
        <div class="container">


            <!-- Content start !-->
            <div class="content">


                <h1 class="frontpageheadline">Velkommen til Burgerklubben!</h1>

                <div class="cdmnews">
                    <h2 class="hapserburgernewoffer">Smag den nye Hapserburger, så meget bedre end McDonalds!
                        <br />
                        saftig bøf, lille klat ost, syltede rødløg og bearnaise! </h2>
                    <div class="d-flex justify-content-center">
                        <div class="vignette">
                            <img class="hapserburger" src="images/Hapserburger.png" alt="Alternate Text" />
                        </div>
                    </div>
                    <h2 class="hapserburgernewofferprice">KUN 45 KR.</h2>
                </div>

                <div class="row youtubevids">
                    <div class="col-lg-5 col-sm-12 d-flex justify-content-lg-end justify-content-sm-center">
                        <iframe width="420" height="315" src="https://www.youtube.com/embed/FHqd3LguZRw"></iframe>
                    </div>
                    <div class="col-lg-2 col-sm-0 d-flex"></div>
                    <div class="col-lg-5 col-sm-12 d-flex justify-content-lg-start justify-content-sm-center">
                        <iframe width="420" height="315" src="https://www.youtube.com/embed/VouHsplrdP0"></iframe>
                    </div>
                </div>


                <h1 class="goodbye">Vi håber snart at se jer!
                    <br />
                    På Gensyn!</h1>

                <!-- Content end !-->
            </div>

            <!-- Container end !-->
        </div>

        <!-- Footer Start !-->
        <div class="footer container-fluid">
            <div class="row justify-content-center">
                <div class="col-lg-3"></div>
                <div class="col-lg-6 footer-info">
                    <p>Burgerklubben | Tlf: 12 34 56 78 | Ahorn Allé 5, 4100 Ringsted</p>
                </div>
                <div class="col-lg-3">
                    <a href="https://www.trustpilot.dk" target="_blank" rel="nofollow noreferrer">
                        <img src="images/Trustpilot_logo.png" />
                        <a />
                </div>
            </div>
            <!-- Footer end !-->
        </div>

    </form>
    <!-- Bootstrap !-->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.6.0/dist/umd/popper.min.js" integrity="sha384-KsvD1yqQ1/1+IA7gi3P0tyJcT3vR+NdBTt13hSJ2lnve8agRGXTTyNaBYmCR/Nwi" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.min.js" integrity="sha384-nsg8ua9HAw1y0W1btsyWgBklPnCUAFLuTMS2G72MMONqmOymq585AcH49TLBQObG" crossorigin="anonymous"></script>
</body>
</html>
