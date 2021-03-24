# Library_Management_Activity

1.2 Scope </br>
The scope of this product is to bring the classical library to everyone without the necessity of going to a specific place to see the available books in order to borrow them. Within this application, we want to make a friendly environment for the readers, where they can easily access any of the application features and make their “stay” as comfortable as we can.</br>
The application is intended to provide the following goals and objectives:</br>
→ To build a system that can receive input and automatically generate output in an easy way and short time.</br>
→  Simplify search/discovery of library resources. </br>
→  To build a monitoring system that is able to monitor and manage all library operations efficiently. </br>
→ To enter and preserve details of the various issues and keep a track on their returns</br>
→ The ability to manage the book inventory database including remove, change, and add through PC.</br>
→ The application will provide to the users the  search function on books based on subject, title, or author.</br>
→ Provide the possibility of  registration online at any desired time</br>
The application will provide the following benefits:</br>
 →  Provide additional flexibility and convenience to the library users.</br>
 →  Provide better reliability and security of the library information.</br> 
 →  Provide a more productive environment for the library staff member. </br>
 →  Reduce the cost of the library operations.</br>
 → The availability of information at any time in any place </br>
1.3 Overview</br>
This document completely describes the system at the architecture level, including subsystems and their services, data management, component design which will describe what each component does in a more systematic way and human interface design which will provide the functionality of the system from the user’s perspective . The document is organized into eight major sections. Each section provides detailed sub-sections relevant to the major section. Charts, tables, and graphics have been inserted to explain or clarify content.</br>
2. System Overview</br>
![UseCase3](https://user-images.githubusercontent.com/59791852/112335475-f1044680-8cc4-11eb-886a-ae422393cd67.png)</br>
The Use Case Diagram will provide a basic overview of the online library application. There will be two main categories of users: authenticated and unauthenticated users. The number of actions of an unauthenticated user is limited since that person can only register or login.</br>
	The authenticated users can also be of two types: members who are the readers registered in the library or staff who are people that are working in the library. There are some common functionalities for these two types of users. Both of them can see all the books, access information about a specific book and also search for a book.Branches can have different books, which is why it is important for users to have access to all the branches. The search has different filters such as: title, author, genre, branch. More than that, an authenticated user can access a help section in which there will be some information regarding how the application works. They can also view their own reports. There will be two types of reports: personal information report in which all the personal information of the user will be kept and history of borrowed books report where a person can see all the books he/she has issued since they are registered to this library. Of course, any user can edit the personal information report.</br>
	There are also some differences between the two types of authenticated users. Members can also borrow books from any branch they want. More than that, they will have a special section in which they can see all the books they have in possession and announce the intention of returning or renewing one book. On the other hand, staff members can add, delete or update books in the branches. They can also see the members and their reports. They have the authority to modify all types of reports of the members.
	After finishing what they wanted to do, users can log out.</br>
3.2 Decomposition Description</br>
1.User Login - both member and staff should introduce the username and password and hit the login button. If everything is ok they will be redirected to the homepage, otherwise they will have to introduce the username and password again.</br>
![login](https://user-images.githubusercontent.com/59791852/112337529-a7b4f680-8cc6-11eb-80d7-b7563b2cb893.png)</br>
4.Edit Member’s Report - this action will be done by staff users. Only after they successfully login, they can choose to view the members, select one member in order to see his/her reports. After that, staff will see an “Edit” button besides each report. They can press on any “Edit” button they want, enter the new details of the report and save the modifications. If some fields will remain incomplete, when clicking the “Save” button they will be warned that they need to fulfil a specific field. If everything works alright, after saving the new information added, the staff will be redirected to the member’s updated report.</br>
![EditMembersReport](https://user-images.githubusercontent.com/59791852/112337620-c1563e00-8cc6-11eb-8d7e-2c603ae79fbb.png)</br>
5.Borrow book - members can borrow books but only after they successfully logged in. After this step they have to choose a branch from where they want to borrow a book. After selecting the view books and all the books will be displayed, so the person can press the “Borrow” button which is text to the book. After that button is pressed, the application will check if the book is still available for borrowing, then it will check if the member is desired (which means he/she never  turned in a book later than the due date). After these steps are completed and they are successful, the book will be reserved for that member and this will modify both the quantity of books available and the history of borrowed books report. The member will be redirected to the books’ report page.</br>
![MemberBorrowBook](https://user-images.githubusercontent.com/59791852/112337700-d3d07780-8cc6-11eb-85bb-c6a74559e11c.png)</br>
6.Renew book - the members have also the option of renewing a book they have in possession. After they successfully log in, they can choose to see the books they borrowed. Then, a list of borrowed books at this time will be available. The member can choose to prolong the due date by one week by clicking on the “Renew” button beside the book. If everything works fine, the due date in the borrowed books report will be changed. The member will be redirected to the report page.</br>
![MemberRenewBook](https://user-images.githubusercontent.com/59791852/112337779-e21e9380-8cc6-11eb-8234-c2291db57899.png)</br>
7.Return book - the members have also the option of returning a book they have in possession. After they successfully log in, they can choose to see the books they borrowed. Then, a list of borrowed books at this time will be available. The member can choose to return by clicking on the “Return” button beside the book. If everything works fine, the book will appear as returned in the borrowed books report and the number of available books of that type will be updated. The member will be redirected to the report page.
![MemberReturnBook](https://user-images.githubusercontent.com/59791852/112337823-f06caf80-8cc6-11eb-99eb-f259312f7f03.png)</br>
11.User search - Both member and staff users can search a book, but only after they are successfully logged in. After that step they have to select the filter. They have 3 possible filters: title, author, genre and branch . After selecting one of these filters, the user must introduce the information regarding the filter and select the “Search” button. If the book is found, then it will be displayed, otherwise the user will be asked to introduce again the data which will be searched.  </br>

6.2 Screen Images</br>
![WelcomePage](https://user-images.githubusercontent.com/59791852/112338466-7e489a80-8cc7-11eb-9edc-c960a8f51e54.PNG)
![LoginPage](https://user-images.githubusercontent.com/59791852/112338475-7f79c780-8cc7-11eb-8bf7-06f3735b2e72.PNG)
![MenuAdmin](https://user-images.githubusercontent.com/59791852/112338476-7f79c780-8cc7-11eb-8aea-a667b84d9999.PNG)
![MenuMember](https://user-images.githubusercontent.com/59791852/112338480-80125e00-8cc7-11eb-95b8-47b604782878.PNG)
![RegisterPage](https://user-images.githubusercontent.com/59791852/112338484-81438b00-8cc7-11eb-93e0-e96d45467c82.PNG)
![UserSearchActivity](https://user-images.githubusercontent.com/59791852/112338131-36c20e80-8cc7-11eb-982d-fc1627425fb2.png)
![SearchAfterTitle](https://user-images.githubusercontent.com/59791852/112338461-7c7ed700-8cc7-11eb-84dd-4e2ec3c43b86.PNG)
![SearcPageAdmin](https://user-images.githubusercontent.com/59791852/112338465-7db00400-8cc7-11eb-9ae0-91d42a407433.PNG)
![branchMember](https://user-images.githubusercontent.com/59791852/112338470-7ee13100-8cc7-11eb-963a-d1949ecb3df3.PNG)






