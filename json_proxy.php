<?php
// Set your return content type
header('Content-type: application/json');

if(empty($_GET['url']))
{
  echo 'You need to specify a valid url';
}
else if(file_exists($_GET['url']))
{
  echo 'STOP THAT. YOU ARE MAKING THE SERVER CRY.';
}
else
{
  // Website url to open
  $daurl = $_GET['url'];

  // Get that website's content
  $handle = fopen($daurl, "r");

  // If there is something, read and return
  if ($handle) 
  {
    $max = 16384;
    
    for ($i = 0; !feof($handle) && $i < $max; $i++) 
    {
      $buffer = fgets($handle, 4096);
      echo $buffer;
    }
    fclose($handle);
    
    if($i == $max)
      echo '/* REQUEST TOO LONG. ' . ($max*4/32) . ' KB MAX */';
  }
}
?>