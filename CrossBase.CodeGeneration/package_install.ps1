param($installPath, $toolsPath, $package, $project)
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms");

Function FindProject($projects, $name)
{
    foreach ($proj in $projects) 
    {
        if ($proj.Kind -eq "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}") 
        {
            $a = @()
            foreach ($prtemp in $proj.ProjectItems)
            {
                $a += $prtemp.Subproject;
            }

            $prtemp = ParseProjects $a $name
            if ($prtemp -ne $null)
            {
                return $prtemp
            }
        }
        else 
        { 
            if ($proj.Kind -eq "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}")
            { 
                if ($proj.Name -eq $name)
                {
                    return $proj
                }
            }
        }
    }
    return;
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

if ($project.Name -ne "CrossBase.CodeGeneration") 
{ 
	[Windows.Forms.MessageBox]::Show("Error, please install this package only to a project named: 'CrossBase.CodeGeneration'");
	throw [system.Exception];
}
ParseItems($project.ProjectItems);

$cross = FindProject $dte.Solution.Projects "CrossBase"

if ($cross -eq $null) 
{ 
	[Windows.Forms.MessageBox]::Show("Error, cannot find a project named'CrossBase' in this solution. CrossBase.CodeGeneration depends on CrossBase package so please install it first");
	throw [system.Exception];
}

$ref = $project.References.AddProject($cross)
