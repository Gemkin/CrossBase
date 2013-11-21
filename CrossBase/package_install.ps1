param($installPath, $toolsPath, $package, $project)
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms");
 
if ($project.Name -ne "CrossBase") 
{ 
	[Windows.Forms.MessageBox]::Show("Error, please install this package only to a project named: 'CrossBase'");
	throw [system.Exception];
}

Function ParseFile($item)
{
	if ($item.Name.EndsWith(".tt") -and $item.Name.Contains("Template"))
	{
		Write-Host  Setting property 'CustomTool' of template $item.Name TextTemplatingFilePreprocessor
		$item.Properties.Item("CustomTool").Value = "TextTemplatingFilePreprocessor";
	}
}

Function ParseItems($items)
{
	ForEach ($item in $items) 
	{ 
		if ($item.Kind -eq "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}") 
		{
			
			ParseFile($item);
		}
		elseif ($item.Kind -eq "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}") 
		{
			ParseItems($item.ProjectItems);
		}
	}
}

ParseItems($project.ProjectItems);
