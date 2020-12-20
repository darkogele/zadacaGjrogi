export function Company({config}) {
    return (
     <div>
       <h1>Company</h1>
       <input type="text" placeholder="Name" onChange={e => config.setCompany({...config.company, name: e.target.value})} />
       <input type="text" placeholder="Phone" onChange={e => config.setCompany({...config.company, phone: e.target.value})} />
       <input type="text" placeholder="Email" onChange={e => config.setCompany({...config.company, email: e.target.value})} />
     </div>
    );
  }