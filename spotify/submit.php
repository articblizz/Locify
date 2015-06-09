<?php

	storeIp();
	
	checkForBannedIp();
	
	checkIfSongIsBanned();

	$link = $_POST["url"];
	if(startsWith($link, "spotify:track:"))
	{
		$file = "queue.txt";
		$current = file_get_contents($file);
		
		if($current != "")
		{
			$current .= "\r\n";
		}
		$current .= $_POST["url"];
		
		file_put_contents($file, $current);
	}

	avsluta();
	
	function avsluta()
	{
		header("Location: /../spotify");
		exit;
	}
		
	function startsWith($haystack, $needle)
	{
		return $needle === "" || strpos($haystack, $needle) === 0;
	}
	
	function checkForBannedIp()
	{
		$ip = null;
		if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
			$ip = $_SERVER['HTTP_CLIENT_IP'];
		} elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
			$ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
		} else {
			$ip = $_SERVER['REMOTE_ADDR'];
		}
		
		$banned = false;

		$lines = file("bannedips.txt", FILE_IGNORE_NEW_LINES);
		foreach($lines as $line_num => $line)
		{
			if($line != "")
			{

				if($line == $ip)
				{
					$banned = true;
				}
			}
		}

		if($banned)
		{
			echo '<script language="javascript">';
			echo 'alert("Din ip e bannad, lol n00b")';
			echo '</script>';
			exit;
		}
	}
	
	function storeIp()
	{
		$ip = null;
		if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
			$ip = $_SERVER['HTTP_CLIENT_IP'];
		} elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
			$ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
		} else {
			$ip = $_SERVER['REMOTE_ADDR'];
		}
		
		$ips = file_get_contents("visitedips.txt");
		$adding = true;
		
		$file1 = "visitedips.txt";
		$lines = file($file1, FILE_IGNORE_NEW_LINES);
		foreach($lines as $line_num => $line)
		{
			if($line != "")
			{

				if($line == $ip)
				{

					$adding = false;
				}
				else
				{
					//echo $line . " is not " . $ip . "<br>";
				}
			}
		}

		if($adding)
		{
			$ips .= "\r\n" . $ip;
			file_put_contents("visitedips.txt", $ips);
		}
	}
	
	function checkIfSongIsBanned()
	{
		$song = $_POST["url"];
		
		$banned = false;

		$lines = file("bannedsongs.txt", FILE_IGNORE_NEW_LINES);
		foreach($lines as $line_num => $line)
		{
			if($line != "")
			{
				if($line == $song)
				{
					$banned = true;
				}
			}
		}

		if($banned)
		{
			avsluta();
		}
	}
?>