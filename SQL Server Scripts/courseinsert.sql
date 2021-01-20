--insert statement
INSERT INTO [DATABASENAME].[dbo].[Courses]
           ([ProgramId]
		   ,[CourseNumber]
           ,[Title]
           ,[CreditHours]
           ,[TuitionAmount]
           ,[Notes]
           ,[AssignmentWeight]
           ,[MidtermWeight]
           ,[FinalWeight]
           ,[MaximumAttempts]
           ,[Discriminator])
     VALUES
(4,'G-100006','Basic Food Prep',5,1220,'Course Import',.30,.35,.35,null,'GradedCourse')
,(2,'G-100007','Animal Breeds',5,1220,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100008','Animal Behaviours',5,1000,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100009','Veterinary Care 1',5,1000,'Course Import',.60,.20,.20,null,'GradedCourse')
,(2,'G-100010','Veterinary Care 2',5,1220,'Course Import',.60,.20,.20,null,'GradedCourse')
,(2,'G-100011','Parasitology',5,1220,'Course Import',.10,.45,.45,null,'GradedCourse')
,(3,'G-100012','Introduction to Baking',5,500,'Course Import',.10,.45,.45,null,'GradedCourse')
,(3,'G-100013','Pastries',5,500,'Course Import',.60,.20,.20,null,'GradedCourse')
,(3,'G-100014','Fondant',5,1220,'Course Import',.60,.20,.20,null,'GradedCourse')
,(3,'G-100015','Chocolatier Level 1',5,1220,'Course Import',.10,.45,.45,null,'GradedCourse')
,(3,'G-100016','Chocolatier Level 2',5,1000,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100017','Animal Nutrition',5,500,'Course Import',.60,.20,.20,null,'GradedCourse')
,(2,'G-100018','Animal Oral Care',5,1000,'Course Import',.60,.20,.20,null,'GradedCourse')
,(2,'G-100019','Animal Blood Typing',5,1000,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100020','Animal Blood Transfusions',5,1220,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100021','Behaviour Modification',5,500,'Course Import',.60,.20,.20,null,'GradedCourse')
,(1,'G-100022','Science 2',5,500,'Course Import',.60,.20,.20,null,'GradedCourse')
,(4,'G-100023','Short Order Cooking',5,1220,'Course Import',.10,.45,.45,null,'GradedCourse')
,(1,'G-100024','CAD Fundamentals',5,1000,'Course Import',.10,.45,.45,null,'GradedCourse')
,(4,'G-100025','Introduction to Culinary Arts',5,1000,'Course Import',.60,.20,.20,null,'GradedCourse')
,(1,'G-100026','Gas Welding',5,500,'Course Import',.60,.20,.20,null,'GradedCourse')
,(2,'G-100027','Blood Analysis',5,500,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'G-100028','Veterinary Assistant 1',5,1000,'Course Import',.10,.45,.45,null,'GradedCourse')
,(2,'M-50029','Veterinary Assistant 2',5,1220,'Course Import',null,null,null,4,'MasteryCourse')
,(2,'M-50030','Pet Owner Communication',5,1220,'Course Import',null,null,null,1,'MasteryCourse')
,(2,'M-50031','Zoo Dynamics',5,500,'Course Import',null,null,null,1,'MasteryCourse')
,(4,'M-50032','Menu Development',5,1000,'Course Import',null,null,null,1,'MasteryCourse')
,(1,'M-50033','MIG Welding',5,500,'Course Import',null,null,null,1,'MasteryCourse')
,(3,'M-50034','Cookies',5,500,'Course Import',null,null,null,2,'MasteryCourse')
,(3,'M-50035','Cakes and Desserts',5,500,'Course Import',null,null,null,10,'MasteryCourse')
,(3,'M-50036','Bread 1',5,1000,'Course Import',null,null,null,2,'MasteryCourse')
,(3,'M-50037','Bread 2',5,1000,'Course Import',null,null,null,1,'MasteryCourse')
,(3,'M-50038','Baking Temperatures',5,1220,'Course Import',null,null,null,2,'MasteryCourse')
,(4,'M-50039','Mixology',5,500,'Course Import',null,null,null,3,'MasteryCourse')
,(1,'M-50040','Customer Relations',5,500,'Course Import',null,null,null,3,'MasteryCourse')
,(4,'M-50041','Supplier Relations',5,1220,'Course Import',null,null,null,3,'MasteryCourse')
,(1,'M-50042','Spot Welding',5,1000,'Course Import',null,null,null,3,'MasteryCourse')
,(4,'M-50043','Food Safe Environments',5,500,'Course Import',null,null,null,6,'MasteryCourse')
,(3,'M-50044','Refrigerated Desserts',5,500,'Course Import',null,null,null,10,'MasteryCourse')
,(2,'M-10060','VT WHMIS',0,1000,'Course Import',null,null,null,3,'MasteryCourse')
,(2,'M-10070','VT Safety Practices',2,1220,'Course Import',null,null,null,3,'MasteryCourse')
,(2,'M-10080','Caring for Orphan Animals',2,500,'Course Import',null,null,null,1,'MasteryCourse')
,(3,'M-10090','PBP WHMIS',2,500,'Course Import',null,null,null,99,'MasteryCourse')
,(3,'M-10100','Emergency First Aid',2,1220,'Course Import',null,null,null,3,'MasteryCourse')
,(NULL,'M-10110','Standard First Aid',2,1220,'Course Import',null,null,null,3,'MasteryCourse')
,(NULL,'M-10120','Baking Professional Development',5,1000,'Course Import',null,null,null,1,'MasteryCourse')
,(NULL,'M-10130','Examination Room Hygiene',5,1000,'Course Import',null,null,null,1,'MasteryCourse')
,(2,'M-10140','VT CO-OP Prep 1',5,500,'Course Import',null,null,null,3,'MasteryCourse')
,(2,'M-10150','VT CO-OP Prep 2',3,500,'Course Import',null,null,null,3,'MasteryCourse')
,(2,'M-10160','VT Career Options',3,500,'Course Import',null,null,null,1,'MasteryCourse')
,(1,'M-10170','Burn First Aid',2,1220,'Course Import',null,null,null,99,'MasteryCourse')
,(4,'M-10180','CA CO-OP Prep 1',2,1220,'Course Import',null,null,null,3,'MasteryCourse')
,(3,'M-10190','Oven Cleaning',2,1000,'Course Import',null,null,null,3,'MasteryCourse')
,(1,'M-10200','Machining Communications',1,500,'Course Import',null,null,null,1,'MasteryCourse')
,(2,'M-10210','VT Educational Options',2,500,'Course Import',null,null,null,99,'MasteryCourse')
,(4,'M-10220','CA CO-OP Prep 2',0,500,'Course Import',null,null,null,3,'MasteryCourse')
,(2,'M-10230','VT Entreprener Options',0,1000,'Course Import',null,null,null,3,'MasteryCourse')
,(1,'A-0600','Precision Metals',0,1220,'Course Import',null,null,null,null,'AuditCourse')
,(4,'A-0700','Wine Tasting',0,240,'Course Import',null,null,null,null,'AuditCourse')
,(3,'A-0800','Baking Entrepreneurs',0,240,'Course Import',null,null,null,null,'AuditCourse')
,(2,'A-0900','Shelter Volunteer Audit 1',0,1220,'Course Import',null,null,null,null,'AuditCourse')
,(2,'A-1000','Shelter Volunteer Audit 2',0,125,'Course Import',null,null,null,null,'AuditCourse')
,(3,'A-1100','Cook Book Development',0,240,'Course Import',null,null,null,null,'AuditCourse')
,(3,'A-1200','Baking Utensils',0,240,'Course Import',null,null,null,null,'AuditCourse')
,(1,'A-1300','Machining CO-OP',0,125,'Course Import',null,null,null,null,'AuditCourse')
,(4,'A-1400','Spirit Tasting',0,125,'Course Import',null,null,null,null,'AuditCourse')
,(5,'A-1555','ECE History',0,125,'Course Import',null,null,null,null,'AuditCourse')
,(6,'A-1666','Carpentry Basics',0,125,'Course Import',null,null,null,null,'AuditCourse')

GO


