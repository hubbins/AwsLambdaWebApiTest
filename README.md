Deploy a .NET Core 1.0 WebAPI service on AWS Lambda using VS2017.

[Uses the AWS Toolkit for VS2017.](https://aws.amazon.com/visualstudio/)

Create a default .NET Core 1.0 (not 1.1) WebApi project.  1.1 is not supported on Lambda.

Add the 4 lines to the project:
* PreserveCompilationContext (including the weird trailing \\)
* Two Amazon package references in the second ItemGroup
* One Amazon package reference in the third ItemGroup

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp1.0</TargetFramework>
    <PreserveCompilationContext>false\</PreserveCompilationContext>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="wwwroot\" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Amazon.Lambda.AspNetCoreServer" Version="0.10.2-preview1" />
    <PackageReference Include="Amazon.Lambda.Tools" Version="1.6.0" />
    <PackageReference Include="Microsoft.ApplicationInsights.AspNetCore" Version="2.0.0" />
    <PackageReference Include="Microsoft.AspNetCore" Version="1.0.5" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="1.0.4" />
    <PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="1.0.2" />
    <PackageReference Include="System.IO" Version="4.3.0" />
  </ItemGroup>
  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="1.0.1" />
    <DotNetCliToolReference Include="Amazon.Lambda.Tools" Version="1.6.0" />
  </ItemGroup>

</Project>
```

May need to reload the solution after add the tool reference.

Right-click and "Add" the serverless.template or copy the code and change this one line to the full function name:
* "Handler": "AwsLambdaWebApiTest::AwsLambdaWebApiTest.LambdaFunction::FunctionHandlerAsync",

Then deploy to Lambda using "Publish to AWS Lambda...".

Use the given API Gateway url and add /api/values to see the response.

I think those are all the steps needed.
