This is the KPI PLugin project for Open Dental.

To add your KPI:
- Add KPI class with query to the appropriate folder. PLEASE follow the same namespace as other classes. 
- Add KPI form and add your KPI to the KPIFormMore file. Again, look at existing forms and use the same namimg conventions for your class. Resolve any issues with dependencies. 

For testing please use a clean copy of opendental; one that does not have any KPI stuff. The idea is to test adding a plugin and not relyign on classes you may have added.
I have one OpenDental project for dev and one clean OpenDental for testing. For dev it is fine to tweak the dev version, but once you are ready for compiling the plugin test it
with the fresh OD.

To compile:

1) Open the solution (.sln file). You may get errors about some projects not being found.

2) To fix the errors, remove both the OpenDental project and the OpenDentBusiness project by right clicking on them in the VS Solution explorer. Then, right click on the solution and add existing projects. Browse to ...\OpenDental\OpenDental.csproj, and add it.  Also, browse to ...\OpenDentBusiness\OpenDentBusiness.csproj, and add it.
**Important: You must add as existing projects from a FRESH COPY of Open Dental. DO NOT USE the one you have been working on. Download it again (fresh) and compile it.**

3) In Solution explorer, expand the PluginExample project, References folder. Right click, Add Reference... , Solution, OpenDental and OpenDentBusiness.

4)If there are now build errors due to metadata files that could not be found, then go build both of those projects from within the head Solution first.

5) In Solution explorer, right click on the project, Edit Properties. Go to the Build Events tab, and edit the post-build event command line. Carefully fix the absolute path to the batch file that is included with the example.

6) Find the batch file using Windows explorer. Right click, edit. Carefully fix the absolute paths contained within it.
Try to build. If no errors, PluginExample.dll will now be found in the debug folder of OpenDental head. IF YOU DO NOT DO THIS YOU WILL HAVE TO MANUALLY COPY THE DLL.

7) Set the Open Dental project to be the startup project (right click). 

8) Enable the plugin by adding a Program Link as described in our install docs.
