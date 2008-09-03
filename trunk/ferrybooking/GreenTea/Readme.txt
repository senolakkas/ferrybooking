GreenTea.Utils package

	+ Design By Contract module
	
	+ Global Error Handling(Not finish yet)
	
	+ OQL (Object Query Language)
		Example:
		    
		    OQL suboql = new OQL(typeof(Person))
                .AddCondition(Condition.IsNotNull("ExprieDate"));
            
            OQL oql = new OQL(typeof(Person))
                .AddAssociation("Kids", "ki", JoinMode.LeftOuterJoin)
                .Distinct()
                .SelectAvg("Age","avg_age")
                .SelectCount("ki.FirstName")
                .SelectProperty("FirstName")
                .AddCondition(Condition.Eq("FirstName", "Smith"))
                .AddCondition(Condition.Disjunction()
                    .AddCondition(Condition.Between("Age", 24, 45))
                    .AddCondition(Condition.Like("FirstName", "Lily"))
                    )
                .AddCondition(SubOQL.Exists(suboql))
                
                .GroupBy("FirstName").GroupBy("LastName")
                .OrderBy("FirstName").OrderBy("LastName");
		
	+ TODO: Get single value from OQL