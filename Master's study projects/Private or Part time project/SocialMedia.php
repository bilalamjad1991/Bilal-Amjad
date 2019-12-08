<!DOCTYPE html>
<html>
<head>
<title>VISMA</title>
<meta name ="viewport" content ="width=device-width, initial-scale=1">
<link rel="stylesheet" href="style.css"> 
<link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
<style>
body{
	background:white;
	margin:0;
}
.menu{
	width:100%;
	background:#142b47;
	overflow: auto;
}
.menu ul {
	
	padding:0;
	list-style:none;
	line-height:60px;
}
.menu li{
	float:left;
	
}
.menu ul li a{
	background:#142b47;
	text-decoration:none;
	width:130px;
	display:block;
	text-align:center;
	color:#f2f2f2;
	font-size:18px;
	font-family:sans-serif;
	letter-spacing:0.5px;
}
.menu li a:hover{
	color:#fff;
	opacity:0.5;
	font-size:19px;
}
.search-form{
	margin-top:0px;
	float:right;
	margin-right:100px;
}
input[type=text]{
	padding:7px;
	border:none;
	font-size:16px;
	font-family:sans-serif;
}
#cartTextbox{
	border: 1px solid grey ;
}
button{
	float:right;
	background:orange;
	color:white;
	border-radius:0 5px 5px 0;
	cursor:pointer;
	position:relative;
	padding:7px;
	font-family:sans-serif;
	border:none;
	font-size:16px;
}
img{
	padding-top:20px;
}

.social-menu ul{
    position:relative;
	<!--top:50%;
	left:50%;-->
	padding:0;
	margin:0;
	transform: translate(-50%,-50%);
	display:flex;
	background-color:grey;
}
.social-menu ul li{
	list-style:none;
	margin: 0 15px;
}
.social-menu ul li .fa{
	font-size: 30px;
	line-height: 60px;
	transition: .6s;
	color: #000;
}
.social-menu ul li .fa:hover {
	color: #fff;
}
.social-menu ul li a {
	position:relative;
	display:block;
	width: 60px;
	height: 60px;
	border-radius: 50%;
	background-color: #fff;
	text-align: center;
	transition: .6s;
	box-shadow: 0 5px 4px rgba(0,0,0,.5);
}
.social-menu ul li a:hover {
	transform: translate(0, -10px);
}
.social-menu ul li:nth-child(1) a:hover{
	background-color: #3b5999;
}
.social-menu ul li:nth-child(2) a:hover{
	background-color: #55acee;
}
.social-menu ul li:nth-child(3) a:hover{
	background-color: #e4405f;
}
.social-menu ul li:nth-child(4) a:hover{
	background-color: #0077B5;
}
.signup-form{
	
	float:right;
	<!--margin-left:600px;-->
	margin-top:0px;
	
	margin-right:100px;
}
footer{
	display:block;
	background-color:grey;
	margin-top:5%;
	
	 box-sizing: border-box;
}


.column {
  float: left;
  width: 50%;
  padding: 10px;
  height: 300px; 
}


.row:after {
  content: "";
  display: table;
  clear: both;
}

</style>
</head>

<body>
<img src="/images/visma logo.png" width="250" height="100"><hr>


<nav class="menu">

    <ul>
	<li><a href="index.php"> Home</a></li>
	<li><a href="#"> Gallery</a></li>
	<li><a href="#"> Event</a></li>
	<li><a href="#"> Feedback</a></li>
	<li><a href="#"> About</a></li>
	<li><a href="#"> Contact</a></li>
	</ul>
	
	<form class ="search-form">
	<input type ="text" placeholder ="Search Products...">
    <button> Search</button>

	</form>
</nav>

<div class="container">
<br>
<center>
<a href="viewCart.php" class="btn btn-warning col-lg-2" > View Cart</a>
</center>
<br>
<br>
<table class="table">

<thead>
<tr>
<th>Name</th>
<th>Image</th>
<th>Price</th>
</tr>
</thead>
<form action="insertCart.php" method="post">
<tbody>
<tr>
<td>Shirt</td>
<td><img  src="images/tshirt.jpg" width="10%"></td>
<td>1000 kr</td>
</tr>

<tr>
<td>Quantity</td>
<td><input  id ="cartTextbox" type="text" name="qty" class="form-control col-lg-6"></td>
<input type="hidden" name="name" value="Shirt">
<input type="hidden" name="price" value="1000">
<td><input type="submit" value="Add Cart" name="addCart" class="btn btn-primary"></td>
</tr>
</tbody>
</form>
</table>
</div>


<br><br><hr>
<footer>
<br><br><br>
<div class="row">
<div class="column">
<div class="social-menu">
	<ul>
	<li><a href='#'><i class="fa fa-facebook"></i></a></li>
	<li><a href='#'><i class="fa fa-twitter"></i></a></li>
	<li><a href='#'><i class="fa fa-instagram"></i></a></li>
	<li><a href='#'><i class="fa fa-linkedin"></i></a></li>
	
	
	
	</ul>
	
	</div>
</div>
<div class="column">
<form class ="signup-form">
	<input type ="text" placeholder ="Email address to Sign Up">
    <button> Sign Up</button>
	</form>
	</div>
	</div>
</footer>



</body>
</html>