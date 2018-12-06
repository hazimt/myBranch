if ($_ -is [System.IO.DirectoryInfo]) { return '' }
if ($_.Attributes -band [System.IO.FileAttributes]::Offline)
{
    return '({0})' -f $_.Length
}
return $_.Length