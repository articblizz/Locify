<html>
<head>
<title>Locify by Feffe</title>
</head>
<body>
<br>
<form action="submit.php" method="post">
Song URI: <input type="text" name="url">
<input type="submit" value="Submit">
</form>

<p1> Använd "Copy Spotify URI", INTE "Copy HTTP Link"!!!!!!! </p1> <br><br>

<?php

$file = "currentlyplaying.txt";
$cp = fopen($file, "r") or die("Can't open file");
$text = fread($cp, filesize($file));
fclose($cp);
echo "<h1 style='font-family: Arial;'> Currently playing: " . $text . "</h1>";

$myFile = "visitors.txt";
$fh = fopen($myFile, 'r') or die("can't open file");

$number = fread($fh, filesize($myFile));
fclose($fh);

echo "<p1 style='color: red;'>" . $number . " visits</p1>" ;

$number++;
	
$fh = fopen($myFile, 'w') or die("can't open file");
$stringData = "Floppy Jalopy\n";
fwrite($fh, $number);
fclose($fh);


?>