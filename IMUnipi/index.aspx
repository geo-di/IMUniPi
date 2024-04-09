<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IMUnipi.index" MasterPageFile="~/site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>
         
            
    <section>
        <h1 style="z-index:100">Welcome to IMUniPi</h1>
            <br/>
            <div style="text-align: center;">
                <video id="vid" autoplay="autoplay" muted="muted" >
                    <source src="media\artepovera.mp4" type="video/mp4"/>
                    
                    Your browser does not support HTML video.
                </video>
            </div>
          
                
       
    </section>

    <div>
        <button  id="show_col" class="button"  runat="server" onserverclick="show_collection"><span>Show Me More</span></button>
         
        


         
        <asp:Image ID="Image1" runat="server" />
         
        


         
    </div>
         


    <section id="s1">
        <div class="container reveal" >
            <h2>Who are we</h2>

            <div class="text-container" >
                <div class="text-box" >
                    <h3> AM: P20040 </h3>
                    <p>
                      
                       Name: Georgellis Dimos
                    </p>
                </div>

                <div class="text-box">
                    <h3> AM: P20207</h3>
                    <p>
                  
                       Name: Psaros Stamatis
                    </p>
                </div>

                <div class="text-box">
                    <h3> AM: P20246</h3>
                    <p>
                 
                       Name: Vlachos Spiridon
                    </p>
                </div>

                <div class="text-box">
                    <h3> AM: P20105</h3>
                    <p>
                   
                       Name: Koutsoudakis Panagiotis
                    </p>
                </div>
            </div>
        </div>
    </section>

    <section id="s2">
        <div class="container reveal" >
            <h2>What is IMUniPi</h2>
            <div class="text-container">
                <div class="text-box"  >
                    <h3>Quick facts</h3>
                    <p>
                       IMUniPi is the largest Video Review platform in the world. Easy to use, 
                       Huge collection of video clips, 
                       Ability to upload videos and rate the videos you see.

                    </p>
                </div>
                <div class="text-box">
                    <h3>Why should you use IMUniPi</h3>
                    <p>
                       IMUniPi gives you access to all the Video clips & songs from every production from all around the world.
                    </p>
                </div>
                <div class="text-box">
                    <h3>Let's Go!</h3>
                    <p>
                       Do not waste anymore of your time. Become a member now and upload your own video clips and Share your thoughts with others.
                    </p>
                </div>
            </div>
        </div>
    </section>



    <section id="s3" runat="server">
        <div class="container reveal" />
            <h2>Register Now</h2>
            <div class="text-container"/>
                <div class="text-box" />
              <h3>Become a member of our community!</h3>
              <button id="btn" class="button" runat="server" onserverclick="btn_ServerClick"><span>Sign Up</span></button>
        </div>
    </section>


    <script>
        //scroll reveal
        function open() {

            document.getElementById("nr").style.width = "100%";
            document.getElementById("cls").style.display = "block";

        }

        function closenav() {
            document.getElementById("nr").style.width = "0%";
            document.getElementById("cls").style.display = "none";
        }

        function reveal() {
            var reveals = document.querySelectorAll(".reveal");

            for (var i = 0; i < reveals.length; i++) {
                var windowHeight = window.innerHeight;
                var elementTop = reveals[i].getBoundingClientRect().top;
                var elementVisible = 150;

                if (elementTop < windowHeight - elementVisible) {
                    reveals[i].classList.add("active");
                } else {
                    reveals[i].classList.remove("active");
                }
            }
        }

        window.addEventListener("scroll", reveal);






    </script>
        
</asp:Content>