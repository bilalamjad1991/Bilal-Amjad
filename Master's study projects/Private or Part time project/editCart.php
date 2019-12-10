<?php
	session_start();
	
	/* This code gets product's name, price and quantity
	for either delete or update purpose from a form present in viewCart.php file
	*/
	
	
	$name = $_POST['name0'];
	$price = $_POST['name1'];
	$quantity = $_POST['name2'];
	$event = $_POST['event'];
	
	$product = array($name,$price,$quantity);

	if($event == "Update"){
		$_SESSION[$name] = $product;
	}
	else if($event == "Delete"){
		unset($_SESSION[$name]);
	}
	
	header('location:viewCart.php');
?>