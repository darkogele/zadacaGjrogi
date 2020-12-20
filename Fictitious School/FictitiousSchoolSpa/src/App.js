import { Courses } from "./components/courses/courses"
import './App.css'; 
import { Company } from "./components/company/company";
import { Participants } from "./components/participants/participants";
import { useEffect, useState } from "react";

function App() {
  // const mainOptions = [
  //   {
  //     "id": 1,
  //     "name": "Cutting trees, the ins and outs",
  //     "dates": ["2017-01-01", "2017-10-31"]
  //   },
  //   {
  //     "id": 2,
  //     "name": "CSS and you - a love story",
  //     "dates": ["2017-05-25", "2017-05-26", "2017-05-27"]
  //   },
  //   {
  //     "id": 3,
  //     "name": "Baking mud cakes using actual mud",
  //     "dates": ["2017-01-01", "2018-12-10", "2017-04-01", "2019-03-12"]
  //   },
  //   {
  //     "id": 4,
  //     "name": "Christmas eve - myth or reality?",
  //     "dates": ["2017-12-24", "2018-12-24", "2019-12-24"]
  //   },
  //   {
  //     "id": 5,
  //     "name": "LEGO colors through time",
  //     "dates": ["2017-06-30"]
  //   }
  // ]; 
  let renderFlag = false;
  let mainOptions = [];

  useEffect (() => {
    const fetchData = async () => {
      const response = await fetch("https://localhost:5001/api/Courses/GetCourses");
      debugger;
      const jsonResponse = await response.json();
      if(jsonResponse) {
        mainOptions = JSON.stringify(jsonResponse);        
      } 
    }

    fetchData();

    // const response = fetch("https://localhost:5001/api/Courses/GetCourses").then(
    //   res
    // );
    
    // const jsonResponse =  response.json();

    // debugger;
    // mainOptions = JSON.stringify(jsonResponse);
  
    // if(mainOptions.length > 1) { renderFlag = true; }
    // else { renderFlag = false; }
  })

  var [courseOption, setCourseOption] = useState();
  var [dateOption, setDateOption] = useState();
  var [company, setCompany] = useState();
  var [participants, setParticipants] = useState([]);

  var courseConfig = {mainOptions, courseOption, setCourseOption, dateOption, setDateOption};
  var companyConfig = {company, setCompany};
  var participantsConfig = {participants, setParticipants};
  
  if(renderFlag === true) { 
 
  }

  return (
    <div className="App">
      <Courses config={courseConfig} />
      <Company config={companyConfig} />
      <Participants config={participantsConfig} />
      <button onClick={async () => {
        var data = {
          "courseId": courseOption.value,
          "courseHours": dateOption,
          "companyDto": {
            "name": company.name,
            "phoneNumber":company.phone,
            "email": company.email
          },
          "participantsDto": participants.map((p, index) => {
            return {
            "id": index,
            "name": p.name,
            "email": p.email,
            "phoneNumber": p.phone}
          })
        }
        const response = await fetch("https://localhost:5001/api/Courses/SubbmitApplication", {
          method: 'POST',
          mode: 'cors', // no-cors, *cors, same-origin
          headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
          body: JSON.stringify(data) // body data type must match "Content-Type" header
        });
      }}>Submit</button>
    </div>
  );
}

export default App;
