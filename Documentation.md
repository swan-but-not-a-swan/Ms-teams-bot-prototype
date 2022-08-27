There are three roles in the Microsoft Teams Bot Prototype. 

Administrator, Teacher, Student

Commands : (Commands are not case sensitive) Every Commands must start with a -

-Create or -c 

-Create Batch [BatchName] -> Creates the batch (Administrator)

-Create Grade [BatchName] [GradeName] -> Creates a grade in a certain batch (Administrator)

-Create Section -> Show Create Section form to create section and the students and teachers in the section. (Administrator)

-Create Tr [Name] [BatchName] [GradeName] [SectionName] [Email] [Subject] -> Creates a teacher into certain section (Administrator)

-Create Meeting -> Creates a new meeting (For teachers who only teach a single class in a single grade in a single batch)

-Create Meeting [SectionName] -> Creates a new meeting (For teachers who teaches multiple classes in a single grade in a single batch)

-Create Meeting -> Create Meeting form will show in order to create a meeting (For teachers who teaches multiples classes in a multiple grades and batches)

-Create Excel [On/Off] -> Tells the program whether to automatically send the period date after meeting to excel or not (Administrator)

-Create Excel [PeriodId] -> Puts the cached meeting information into excel file. (All 3 Roles)

-Create Feedback -> A feedback website will show in order to report bugs or give feedbacks to the developer

-Get or -g

Administrator and Teacher Role will the attendance of the entire class while the Student role will get the attendance of him/her only

-Get Grade [BatchName] [GradeName] -> Gets a single grade information in a certain batch (Administrator)

-Get Section [BatchName] [GradeName] [SectionName] -> Gets a single section information in a certain grade and batch(Administrator and Teacher)

-Get Section -> Gets a single section information of a Student's class (Student)

-Get Attendance -> Get Attendance form will show in order to get attendance (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] -> Gets all the attendance of a certain section in "current" day in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] -> Gets the attendance of a certain section of selected subject in "current" day in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role] -> Gets the attendance of a certain person in certain section  in "current" day in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role] -> Gets the attendance of a certain person in a certain section of selected subject in "current" day in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Month_] -> Gets the attendance of a certain section in a single selected month in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Month_] -> Gets the attendance of a certain section of selected subject in a single selected month in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role] [Month_] -> Gets the attendance of a certain person in a certain section in a single selected month in the certain grade and batch (All 3 roles)

-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role] [Month_] -> Gets the attendance of a certain person in a certain section of a selected subject in a single selected month in the certain grade and batch (All 3 roles)

-Get Help -> Prints out a documentation on the message form (All 3 roles)

Notes#

Names must not have space. Eg SwanSettAung.
Every month must be followed by underscore. Eg August_ .
Every Teacher's email must have "Tr" in front of it . Eg. TrSwan@ilbc.edu.mm .
Every email must have "@ilbc.edu.mm". Eg. SwanSettAung@ilbc.edu.mm .
The program will have intellisense to assit everyone. 









