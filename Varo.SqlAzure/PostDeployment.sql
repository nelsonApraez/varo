-- DATOS SEMILLA  ** TiposTecnologia **
--MERGE INTO dbo.TiposTecnologia AS Target
--USING (VALUES
--		( 1, 'Lenguajes de programación' ),
--		( 2, 'Origenes de datos' ),
--		( 3, 'Frameworks' ),
--		( 4, 'Plataformas' ),
--		( 5, 'Herramientas de trabajo' )
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

--Quitar comentario cuando se sincronice con PDN
---- DATOS SEMILLA  ** Tecnologias **
--MERGE INTO dbo.Tecnologias AS Target
--USING (VALUES
--		('190CEFBD-5CB3-43BF-9C5A-025B3DCC918F',3,'Ember',''),
--('2FCFC9C2-4F31-448F-BAE3-048C0F3595DE',4,'AWS Api Gateway',''),
--('5412B472-3DE2-49F9-BE6F-05635072020F',3,'.Net Web Api',''),
--('470D46EB-88E0-4BDC-BAED-05C7BB0E566F',3,'Vue',''),
--('B9543A65-7CE8-48DA-9DEF-066FFB3B7AB9',2,'Dynamo DB',''),
--('6BC063EE-C7AA-47EE-BC9C-07F3A6D073E9',1,'Swift',''),
--('6CCA1B11-3221-47D1-BDC5-0860258011FD',1,'Java','java.jpg'),
--('708BE692-40AC-4359-941B-0A75306463E7',2,'Hadoop','hadoop.jpg'),
--('5339A6DA-B880-4C28-A4C3-0C5C1A44186F',5,'Spring Tool Suite','springToolSuite.jpg'),
--('B594EEB8-45C1-438B-A5BE-0C5EF1C2E32B',1,'Objective-C',''),
--('1275ECC5-7434-4F4F-A5F7-0F0516AE0DD4',3,'GWT',''),
--('B2F83AC1-7EB8-46BC-8C5E-1113C1D31496',3,'Java EE',''),
--('3A098B17-9FCC-441D-9643-1502F1E493C0',5,'Selenium','selenium.jpg'),
--('54FDCB70-039D-41A0-9749-150C99D45B07',5,'Titanium','titanium.jpg'),
--('16386065-AB5F-48D7-A32E-1859B0D3C71B',2,'SQL server','sqlServer.jpg'),
--('2D0E9F26-D89F-49F8-86E9-193441FD861A',3,'Angular','angular.jpg'),
--('8B47AF93-BAF8-4946-830C-1C042F920FF5',3,'Laravel','laravel.jpg'),
--('E2AA34CF-8AE3-46EF-B6B5-1C63CCFFF9A5',1,'Go',''),
--('1FC668CE-F626-4122-8C27-1E823E3EC74B',1,'PHP','php.jpg'),
--('467D61B2-501B-4732-99B3-1F773E008B6C',2,'MySql','mySql.jpg'),
--('28CC21FA-B5C7-4303-9DC6-202B5298D18F',1,'M','M.jpg'),
--('F62ED40F-D673-4CC2-8722-209E3DFD5ED4',1,'Clojure',''),
--('26F2092D-37D2-4845-8D1B-21270532A693',4,'Dynamics CRM','dynamicsCRM.jpg'),
--('EB5AD33C-FAF4-4623-9072-227935F5EB3E',5,'Android Studio','androidStudio.jpg'),
--('01B0C4E6-4E52-40AB-9DCE-2483267124CA',5,'Swagger','swagger.jpg'),
--('CE4373D5-60AB-4EE8-91EE-2906D5702CC2',1,'Ruby','rubyOnRails.jpg'),
--('C48FBCE0-948C-45E2-9056-2A2B54FE8319',4,'DNN',''),
--('F5663427-B5FD-4DC3-84ED-327AA6540AF3',4,'Azure Functions',''),
--('0DAA1E95-6C57-4663-A603-32E752833E89',1,'Python',''),
--('9CAD5F09-E35F-43DC-8548-33FCDE8BB6AA',5,'Salesforce CLI','salesforceCLI.jpg'),
--('5A07B9AB-FEC1-4C35-A56F-346B56B7D703',4,'Xamarin Classic','xamarinClassic.jpg'),
--('DBF019F7-9137-485E-A450-38A99CBBAFAE',2,'Apache Cassandra',''),
--('383C9699-D8C4-45A8-A55A-38B84D4C67DD',4,'AWS CloudWatch',''),
--('FDA1A8CE-2218-44B3-94A9-3BFD4D2E1FF1',2,'DB2','db2.jpg'),
--('8FC58834-92FD-49B5-BFFE-3F03307BE746',1,'F#',''),
--('C1F6C198-BD82-4541-A07C-3F08C60A2A81',2,'Archivos','archivos.jpg'),
--('AE090183-2481-436A-9F39-40966756493B',5,'Power BI','powerBI.jpg'),
--('773EE59B-4501-4820-9B4A-417B94C8A9A9',5,'Xamarin Studio','xamarinStudio.jpg'),
--('7BE38436-D5C0-41BA-8F51-439BDE1E8AC6',5,'Dataloader','dataloader.jpg'),
--('D29AC029-75EF-4AB0-AE0D-443CFEAFF9CB',5,'Visual Studio','visualStudio.jpg'),
--('38ADB96B-1A52-4EF0-8BBC-45807DEB1112',4,'Enterprise Data Quality Oracle','enterpriseDataQualityOracle.jpg'),
--('BA7C8E9A-4E20-4E71-B745-47C3F4C7C71B',3,'IG Framework ETL','IGFrameworkETL.jpg'),
--('1DBFE266-8836-459C-AF32-487C6EA1B2E0',1,'DAX','DAX.jpg'),
--('C19D9C59-495A-49A4-B48C-493BD6E14C41',2,'PostgreSql','postgreSql.jpg'),
--('B96D2C45-D611-486A-AFCC-4A08447733E5',2,'sObjects','sObjects.jpg'),
--('A431AD9C-5B9E-4F84-A581-4A38EF0F00E5',4,'Azure Api Managment',''),
--('931A7A2E-AB12-40BF-A1C5-4C23ADF2572C',1,'RPG','rpg.jpg'),
--('F546DDC0-70A3-4AF5-8135-4C2DAB350098',5,'Soap UI','soapUI.jpg'),
--('EEBDDACD-CE3C-42D4-863A-4FAA635E19B1',1,'C#','cSharp.jpg'),
--('C3B021A7-83D0-4583-A615-4FAC144276B1',5,'Ant Migration Tool','antMigrationTool.jpg'),
--('D13DA6EC-F393-4BD5-B1C6-50EEE2E6FC9C',4,'Biztalk Server','biztalkServer.jpg'),
--('6ACDCF50-0772-42C4-8666-52DE76B8363B',5,'Visual Studio Code','visualStudioCode.jpg'),
--('CBED03E6-95F9-439D-A2FB-57F128DC0318',4,'Liferay','liferay.jpg'),
--('91574D4C-9D19-4794-9AD6-5A30F85A42DD',4,'Sales Cloud','salesCloud.jpg'),
--('5C00B2C1-56F0-4687-B517-5E435522FFE0',3,'.Net Core',''),
--('DD7FEA9E-1959-4E28-B445-5E9AA245268C',5,'Postman','postman.jpg'),
--('69EEEC61-63FD-4D18-8AB8-5EEB74F9A928',4,'Lightning Platform','lightningPlatform.jpg'),
--('9798A8B5-C015-4351-81FB-5F60D5246F63',4,'AWS Lambda',''),
--('914A69D3-FC9F-4C2A-80A8-5F8900E65355',4,'Azure Aplication Insights',''),
--('37DDB360-3B7D-4B27-A279-5FCDB365817F',4,'Azure Logic Apps',''),
--('173E7908-AC7E-4659-BEA9-60A52BC0841F',2,'Couchbase',''),
--('834718B6-39B4-4A37-9C98-62ED03986855',1,'VB.Net','visualBasic.jpg'),
--('8E82675E-9708-4453-98AB-66349536A549',5,'Xcode','xcode.jpg'),
--('67C93980-EDFB-45E1-A415-6AA07AD7958A',4,'Service Cloud','serviceCloud.jpg'),
--('76D24F18-4A05-48D6-818B-6AA76D4CD6EE',1,'Transact SQL','transactSQL.jpg'),
--('0D601AFA-58C8-4ECE-97AE-6D2687964A1F',1,'Perl',''),
--('B3F66A73-E26A-4DA1-BFFB-719CE39406AA',3,'Spring',''),
--('078710E2-D4D9-4377-8621-7296DF38E974',2,'SQL Azure','sqlAzure.jpg'),
--('022DC560-3E1C-4DF5-AA0A-7304332BA559',1,'MDX','MDX.jpg'),
--('FB8D7801-0D23-4B3E-B6BD-799F38A95554',5,'MySQL','mySQL.jpg'),
--('91F3B880-5F44-4380-AFC6-7DB656192144',1,'Kotlin',''),
--('24B81D00-FA4C-4E3A-B1FB-7E4CD0F1B31C',3,'Ruby on Rails','rubyOnRails.jpg'),
--('22D43027-5F17-4792-816B-7E96B6E1ABF7',3,'Silverlight',''),
--('8CD9A1C3-3EBF-4EAF-8F7A-7F9999F18A53',3,'Lightning Design System','lightningDesignSystem.jpg'),
--('EB6821F3-160B-46B9-9B7C-81952C8A45C6',5,'GitHub Desktop','gitHubDesktop.jpg'),
--('E5780F94-3C79-4E06-84D5-824539464064',5,'PhoneGap','phoneGap.jpg'),
--('BD1D5237-FB3A-4AAA-9F41-84179EBD6975',4,'WebSphere Portal','webSpherePortal.jpg'),
--('38BB2EBE-0DF9-45B2-AE4A-84DD28748246',5,'Reporting Services','reportingServices.jpg'),
--('A75A5075-ABE4-412B-AFE1-8A4D898EA60C',3,'PEAR','pear.jpg'),
--('CD395EEE-1A36-4203-8BA3-9026C530B56A',1,'JavaScript','javaScript.jpg'),
--('004E90D2-1E45-4788-91B1-9161A42B630A',3,'Lightning Aura Components','lightningAuraComponents.jpg'),
--('986AFCBE-7B36-4C3F-8523-93EF78259E48',4,'Community Cloud','communityCloud.jpg'),
--('0EBAB1B0-2E45-4325-9566-994C7F4A65BA',3,'Asp.Net Core MVC',''),
--('C5D644DB-D5AE-421A-A4CD-9C92B1092635',1,'Elixir',''),
--('1C69C9B5-F312-48EB-89EB-9D030EEC38AC',5,'Eclipse','eclipse.jpg'),
--('9B0E50C2-B92A-404B-A9D3-9DA49069279A',3,'.Net Core Web Api',''),
--('15467E60-FA7B-461F-8E24-9F4A7B43888D',5,'Console Developer','consoleDeveloper.jpg'),
--('4E4325AF-51F2-4E64-8EC1-9FAF23B242BA',2,'AWS S3','awsS3.jpg'),
--('FD2A3459-8262-400C-9B10-A1AB5C02C9EF',3,'Simfony',''),
--('387D4C23-7CEC-4684-9294-A38F780BB1AF',3,'ASP.Net Web Forms','aspNetWebForms.jpg'),
--('0BF1C992-BDD5-452B-A8FE-A6C7AC1D2366',5,'Workbench','workbench.jpg'),
--('930E84A8-826B-4BCE-A959-A747F638CDB6',3,'YII','yii.jpg'),
--('FCB0EDC4-39EB-458B-AFEB-A90050A50D10',5,'Gearset','gearset.jpg'),
--('E76504CA-5233-4C5A-BB81-AA8FB15ACE39',4,'Xamarin Forms','xamarinForms.jpg'),
--('A462C130-C729-4CFE-BC78-AAE5130A7267',5,'Integrations Services',''),
--('8E8108C4-89DC-4FC0-84D3-B08E45351A32',1,'R',''),
--('B468B406-4EAC-4DC8-8A39-B1EB86690561',1,'Visualforce','visualforce.jpg'),
--('A6E2D93D-7334-405E-B62A-B33188A0CDDE',2,'Oracle','oracle.jpg'),
--('55A42E36-EF5A-431E-8302-B4D719510575',3,'Django','django.jpg'),
--('C5572626-A9D8-4082-8D88-B53E959FECC4',1,'C++','cmasmas.jpg'),
--('39A3C64C-0CAC-4048-BEBA-B966CEBB8A01',2,'Azure Table Storage','azureTableStorage.jpg'),
--('A6B4EDC5-E408-43B9-8868-BD57DDC9A474',5,'Katalon','katalon.jpg'),
--('F6CE273B-CD2B-4A87-B9AA-BF101F9A3344',3,'Microsoft Bot Framework',''),
--('142713AE-9C9E-4E1B-82B8-BF180079F422',2,'Azure CosmosDB','azureCosmosDB.jpg'),
--('9D121030-FAD6-4599-9F22-C3E244424361',5,'Analisis Services','analisisServices.jpg'),
--('FE38A0C7-A03A-4FE8-AA67-C76AFD987868',4,'AWS Step Functions',''),
--('C43CEB20-E40B-49BC-8D48-C79CC7FB12F3',4,'AWS Route 53','aws.jpg'),
--('FF91F283-FC94-4B44-899E-C8AAA1F0641E',3,'React',''),
--('CA0EAE05-81F9-416C-AA65-CB4752507AC9',4,'Sharepoint',''),
--('F4F4F0FF-2AC9-4D33-94E9-CE129AAC3A2E',3,'Node.Js',''),
--('78282FA7-EE7F-4A3D-A5E2-CE187DFE0A3E',4,'AWS EC2','awsEC2.jpg'),
--('BC305C8D-DAC7-4D15-A3CD-CE3EB6594F6E',5,'Appium','appium.jpg'),
--('CB981640-5132-485D-9D81-D14FB01359B2',1,'C','c.jpg'),
--('AB430836-8A89-49C2-A713-D21D6E216BFF',4,'Wordpress',''),
--('8E0D4A9C-CAB4-4BBE-9B26-D278FF0AA11D',1,'Dart',''),
--('13AC4185-E847-4032-BA21-D2941CCA8014',3,'ASP.Net MVC','aspNetMVC.jpg'),
--('8E6578CF-69AE-47A8-8AB7-D2BA1685EA7E',5,'Jmeter','jmeter.jpg'),
--('D339CA06-E161-4922-AEA2-D4FA5DAEC332',3,'.Net','puntoNet.jpg'),
--('3109C0D4-34C6-4D52-972F-D633C2E7A91D',1,'Css','css.jpg'),
--('FF4D905B-00F0-49E7-8500-DBFF421C400D',2,'Azure Blob Storage','azureBlobStorage.jpg'),
--('8D4D0F8D-52CD-44C2-BBF0-DD1FBCCE89DE',1,'TypeScript',''),
--('9C124438-9E00-46E8-963D-E4F1C4AE0964',2,'Mongo DB',''),
--('EAFE91B7-11E7-4886-B6A0-E7B3079DBEAA',5,'NetBeans','netBeans.jpg'),
--('8C1C8BD0-3473-403C-BCCE-F2D4D09C853B',1,'SOQL/SOSL','SOQLSOSL.jpg'),
--('90CA0B37-F99A-4ABA-AE25-F6344E964B4E',4,'Azure App Service','azureAppService.jpg'),
--('FBD69150-ED9B-44C3-BE19-F71F7A7C4B21',1,'Ápex','apex.jpg'),
--('106C9C2D-A26F-4B89-9D10-FA58C9684162',5,'IDE forcé.com','IDEforcecom.jpg'),
--('A0095973-31C3-46C4-8AF3-FC6BBE222064',5,'Sql Server Management','sqlServerManagement.jpg'),
--('178A4BA4-D123-43B4-9362-FD659DC20B75',1,'Groovy','')
--	  )
--AS Source ( Id, IdTipoTecnologia, Nombre, Logo ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET IdTipoTecnologia = Source.IdTipoTecnologia, 
--	Nombre = Source.Nombre,
--	Logo = Source.Logo

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, IdTipoTecnologia, Nombre, Logo )
--VALUES ( Id, IdTipoTecnologia, Nombre, Logo )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

-- DATOS SEMILLA  ** TiposSolucion **
--MERGE INTO dbo.TiposSolucion AS Target
--USING (VALUES
--		(1, 'Nuevo'),
--		(2, 'Soporte')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

-- DATOS SEMILLA  ** Oficinas **
--MERGE INTO dbo.Oficinas AS Target
--USING (VALUES
--		(1, 'Medellín'),
--		(2, 'Bogotá'),
--		(3, 'Cali'),
--		(4, 'Barranquilla'),
--		(5, 'EPM'),
--		(6, 'Paises')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

---- DATOS SEMILLA  ** MarcosTrabajo **
--MERGE INTO dbo.MarcosTrabajo AS Target
--USING (VALUES
--		(1, 'Ágil'),
--		(2, 'Tradicional')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

-- DATOS SEMILLA  ** LineaTecnologica **
--MERGE INTO dbo.LineaTecnologica AS Target
--USING (VALUES
--		(1, 'BI'),
--		(2, 'CRM'),
--		(3, 'DNN'),
--		(4, 'Integraciones'),
--		(5, 'Lenguaje Orientado a Objetos'),
--		(6, 'Content Management System'),
--		(7, 'Movilidad'),
--		(8, 'Sharepoint'),
--		(9, 'Salesforce'),
--		(10, 'Gobierno de datos')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

-- DATOS SEMILLA  ** LineaNegocio **
--MERGE INTO dbo.LineaNegocio AS Target
--USING (VALUES
--		(1, 'Retail'),
--		(2, 'Utilities'),
--		(3, 'Salud'),
--		(4, 'Gobierno'),
--		(5, 'Financiero'),
--		(6, 'Aseguradoras'),
--		(7, 'Turismo'),
--		(8, 'Caja de Compensación')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;

-- DATOS SEMILLA  ** EstadosSolucion **
--MERGE INTO dbo.EstadosSolucion AS Target
--USING (VALUES
--		(1, 'Ejecución'),
--		(2, 'Cerrado ')
--	  )
--AS Source ( Id, Nombre ) 
--ON Target.Id = Source.Id

--WHEN MATCHED THEN
--UPDATE SET Nombre = Source.Nombre

--WHEN NOT MATCHED BY TARGET THEN
--INSERT ( Id, Nombre )
--VALUES ( Id, Nombre )

--WHEN NOT MATCHED BY SOURCE THEN 
--DELETE;
