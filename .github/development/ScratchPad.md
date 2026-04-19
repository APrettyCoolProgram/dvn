<div align="center">

  <h1>dvn: Scratchpad</h1>

</div>

System.Management.Automation.CommandNotFoundException
  HResult=0x80131501
  Message=The term 'irm get.scoop.sh -outfile 'v:\install.ps1'' is not recognized as a name of a cmdlet, function, script file, or executable program.
Check the spelling of the name, or if a path was included, verify that the path is correct and try again.
  Source=System.Management.Automation
  StackTrace:
   at System.Management.Automation.Runspaces.PipelineBase.Invoke(IEnumerable input)
   at System.Management.Automation.Runspaces.Pipeline.Invoke()
   at System.Management.Automation.PowerShell.Worker.ConstructPipelineAndDoWork(Runspace rs, Boolean performSyncInvoke)
   at System.Management.Automation.PowerShell.Worker.CreateRunspaceIfNeededAndDoWork(Runspace rsToUse, Boolean isSync)
   at System.Management.Automation.PowerShell.CoreInvokeHelper[TInput,TOutput](PSDataCollection`1 input, PSDataCollection`1 output, PSInvocationSettings settings)
   at System.Management.Automation.PowerShell.CoreInvoke[TInput,TOutput](PSDataCollection`1 input, PSDataCollection`1 output, PSInvocationSettings settings)
   at System.Management.Automation.PowerShell.CoreInvoke[TOutput](IEnumerable input, PSDataCollection`1 output, PSInvocationSettings settings)
   at System.Management.Automation.PowerShell.Invoke(IEnumerable input, PSInvocationSettings settings)
   at System.Management.Automation.PowerShell.Invoke()
   at dvn.Scooper.Install.Scoop(String drive) in D:\Repositories\GitHub\APrettyCoolProgram\dvn\src\Scooper\Install.cs:line 22
   at dvn.Program.Main(String[] args) in D:\Repositories\GitHub\APrettyCoolProgram\dvn\src\Program.cs:line 20




***

<br>

<sub>Last updated: 260417</sub>
