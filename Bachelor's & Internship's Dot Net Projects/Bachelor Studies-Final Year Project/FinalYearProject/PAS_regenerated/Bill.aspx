<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill.aspx.cs" Inherits="PAS_regenerated.Bill"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="utf-8" />
	<title>Bill</title>
    
     <link href="Styles/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
     <script type="text/javascript" language="javascript">
         $(function () {
             $('#<%=txtMedicineName.ClientID %>').autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "MedicineService.asmx/GetMedicineNames",
                         data: "{'medicineName':'" + request.term + "'}",
                         type: "POST",
                         dataType: "json",
                         contentType: "application/json;charset=utf-8",
                         success: function (result) {
                             response(result.d);
                         },
                         error: function (result) {
                             alert('There is a problem processing your request');

                         }
                     });
                 }
             });

         });
    </script>



	<link rel="shortcut icon" type="image/x-icon" href="css/images/favicon.ico" />
	<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
	<link rel="stylesheet" href="css/flexslider.css" type="text/css" media="all" />
	
	<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var jq172 = $.noConflict(true);
        </script>
	<!--[if lt IE 9]>
		<script src="js/modernizr.custom.js"></script>
	<![endif]-->
	<script src="js/jquery.flexslider-min.js" type="text/javascript"></script>
	<script src="js/functions.js" type="text/javascript"></script>


    
   


    <script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= lblDuplicate.ClientID %>').style.display = "none";


        }
        setTimeout("HideLabel();", 2000);
    </script>
 
  <script type="text/javascript">
      function HideLabel1() {

          document.getElementById('<%= Label3.ClientID %>').style.display = "none";

      }
      setTimeout("HideLabel1();", 3000);
    </script>

    <script type="text/javascript">
        function HideLabel2() {

            document.getElementById('<%= Label1.ClientID %>').style.display = "none";

        }
        setTimeout("HideLabel2();", 2000);
    </script>
   
</head>
<body>
<form id="form1" runat="server">
	<!-- wrapper -->
	<div id="wrapper">
		<!-- header -->
		<header class="header">
			<div class="shell">
				<h1 id="logo"><a href="Index.aspx">Medic-Care</a></h1>
				
				<!-- navigation -->
				<nav id="navigation" style="padding-right:1%">
					<ul>
						<li class="active">
							<%--<a href="Index.aspx">Home</a>--%>
                             <asp:LinkButton ID="lnkbtnHome" runat="server" onclick="lnkbtnHome_Click">Home</asp:LinkButton>
						<%--	<span>Get Started</span>--%>
						</li>
						<li>
							<a href="searchConsole.aspx">Search Medicine</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                        <li>
							<a href="Bill.aspx">Billing</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                        <li>
							<a href="AttendanceSystem.aspx">Attendance</a>
							<%--<span>Mark Attendance</span>--%>
						</li>
                         <li><asp:LinkButton ID="lnkbtnRegister" runat="server" 
            onclick="lnkbtnRegister_Click" Enabled="False">Register</asp:LinkButton></li>
            </ul>
           
            <ul style="padding-left:60%">
           
            <li style="font-size: 10px "><asp:LinkButton ID="lnkbtnChangePassword" runat="server" 
              onclick="lnkbtnChangePassword_Click">Change Password</asp:LinkButton></li>
      <li style="font-size: 10px"> <asp:LinkButton ID="lnkbtnSignout" runat="server" 
              onclick="lnkbtnSignout_Click">Signout</asp:LinkButton> </li>
						
					</ul>
					<div class="cl">&nbsp;</div>
				</nav>
				<!-- end of navigation -->
			</div>
		</header>
		<!-- end of header -->
		
		<!-- slider-holder -->
		<div class="slider-holder">
			<!-- shell -->
			<div class="shell">
				<span class="l"></span>
				<span class="r"></span>
				<span class="t"></span>
				<span class="b"></span>
				<%--<a href="#" class="slider-btn">Explore Our Showcase</a>--%>
				<!-- slider -->
				<div class="slider flexslider">
					<ul class="slides">
						<li>
							<img src="css/images/slide1.png" alt="" />
							<%--<div class="slide-cnt">
								<div class="box-t"></div>
								<div class="box-c">
									<div class="box-cnt">
										<h2>Lorem Ipsum Dolor Sit Amet</h2>
										<p>Donec vehicula odio quis lobortis varius, quam nibh pulvinar eros, sed aliquam orci sem nec ipsum. Nunc sed felis vitae nisl faucibus convallis sit amet eget dolor. Fusce sodales consectetur adipiscing. Nunc nulla mauris, blandit nec dapibus porta, porta tempus lectus. </p>
									</div>
									<div class="cl">&nbsp;</div>
								</div>
								<div class="box-b"></div>
							</div>	--%>
						</li>
						<li>
							<img src="css/images/slide2.jpg" alt="" />
							<%--<div class="slide-cnt">
								<div class="box-t"></div>
								<div class="box-c">
									<div class="box-cnt">
										<h2>Lorem Ipsum Dolor Sit Amet</h2>
										<p>Donec vehicula odio quis lobortis varius, quam nibh pulvinar eros, sed aliquam orci sem nec ipsum. Nunc sed felis vitae nisl faucibus convallis sit amet eget dolor. Fusce sodales consectetur adipiscing. Nunc nulla mauris, blandit nec dapibus porta, porta tempus lectus. </p>
									</div>
									<div class="cl">&nbsp;</div>
								</div>
								<div class="box-b"></div>
							</div>--%>	
						</li>

                        <li>
							<img src="css/images/slide3.jpg" alt="" />
                        </li>

					</ul>
				</div>
				<!-- end of slider -->
			</div>
			<!-- end of shell -->	
		</div>	
		<!-- end of slider-holder -->
		
		<!-- shell -->
		<div class="shell">
			<!-- main -->
			<div class="main">
				<section class="cols">
					<div> <%--class="col"--%>
						<h3>Bill Generation</h3>
						<p style="color:#F2F2F2">test</p>
                         <div style="height: 182px; width: 700px">
            <asp:Label ID="lblInvoice" runat="server" Text="Invoice #" Font-Bold="True" 
                ForeColor="#11A6D4"></asp:Label>
            <asp:TextBox ID="txtInvoice" runat="server" ReadOnly="True" Width="65px"></asp:TextBox>
            <asp:Label ID="lblMedName" runat="server" Text="Medicine Name : " Font-Bold="True" 
                ForeColor="#11A6D4"></asp:Label><asp:TextBox ID="txtMedicineName" runat="server"></asp:TextBox>
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity : " Font-Bold="True" ForeColor="#11A6D4"></asp:Label>
            <asp:TextBox ID="txtOrderQty" runat="server" Width="86px"></asp:TextBox>
            <asp:Button ID="btnAddtoBill" runat="server" Text="Add To Bill" 
                Font-Bold="True" ForeColor="Black" onclick="btnAddtoBill_Click" Width="113px" />
                <%-- OnClientClick="test()"--%>
           
        <br />
         
        
       
        <asp:Label ID="Label1" runat="server" Text="Label1" Visible="False" 
                ForeColor="#CC0000"></asp:Label>
        
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False" 
                ForeColor="Red"></asp:Label>
            <asp:Label ID="lblDuplicate" runat="server" ForeColor="Red" Visible="False" ></asp:Label>
            <asp:Label ID="Label4" runat="server" 
                ForeColor="Red" Visible="False"></asp:Label>

               
                   
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged1" 
                Visible="False">
            <asp:ListItem Text="Select Medicine" Value="-1"></asp:ListItem>
            </asp:DropDownList>

            <%--<asp:Button ID="Button1" runat="server" Text="Alternate Medicine" 
                onclick="Button1_Click1" Visible="False" />--%>
       
        <br />
           
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="Groove" BorderWidth="3px" 
            CellPadding="5" HorizontalAlign="Justify" ShowFooter="True" PageSize="3" 
                AutoGenerateDeleteButton="True" onrowdeleting="GridView1_RowDeleting" 
                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                AutoGenerateEditButton="True" onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
            <FooterStyle BackColor="White" ForeColor="#000066" BorderStyle="None" 
                Font-Bold="True" Wrap="True" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
          
        

      
        <br />
            <asp:Button ID="btnSaveGrid" runat="server" Text="Generate Bill" 
                onclick="btnSaveGrid_Click" Visible="False" Font-Bold="True" />
    </div>
          
       
						
					</div>

					
					
					<div class="cl">&nbsp;</div>
				</section>
			</div>
			<!-- end of main -->
		</div>
		<!-- end of shell -->
		<div id="footer-push"></div>
	</div>
	<!-- wrapper -->

	<!-- footer -->
	<div id="footer">
		<div class="shell">
			<!-- footer-cols -->
			<section class="footer-cols">
				<div> <%--class="col"--%>
					<h3>MORE <strong>ABOUT US</strong></h3>
					<p>When you come to Medic-Care Pharmacy, you'll be able to count on dependable care from knowledgeable pharmacists and a kind and dedicated support staff. We are wellness specialists committed to your total health, carrying a full line of vitamins and supplements to specialty bandages and first aid products. Our mission is to empower people to make educated health choices while providing prompt, friendly service with quality products. If you do not see what you are looking for, just ask us, we will go out of our way to find it for you.</p>
				</div>
				<%--<div class="col">
					<h3>KEEP <strong>IN TOUCH</strong></h3>
					<p>Cum sociis natoque penatibus et magnis dolor</p>
					<form method="post">
						<input type="text" class="field" value="Your Email Here" title="Your Email Here" />
						<input type="submit" class="submit-btn" value="Submit" />
					</form>
				</div>
				<div class="col contact">
					<h3>CONTACT <strong>US</strong></h3>
					<h4>+ 123 456 78910</h4>
					<a href="#">johndoe@websitename.com</a>
				</div>--%>
				<div class="cl">&nbsp;</div>
			</section>
			<!-- end of footer-cols -->
			<p class="copy">&copy;  Designed by Pioneers </p>
			<div class="cl">&nbsp;</div>
		</div>	
	</div>
	<!-- end of footer -->
    </form>
</body>
</html>
