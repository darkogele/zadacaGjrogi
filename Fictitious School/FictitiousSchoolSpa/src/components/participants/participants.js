import { useState } from "react";

export function Participants({ config }) {
  return (
    <div>
      <h1>Participants</h1>
      {config.participants && <ParticipantList list={config.participants} />}
      <AddParticipant config={config} />
    </div>
  );
}

function ParticipantList({ list }) {
  return list.map((p) => {
    return (
      <div>
        <p>
          {p.name}/{p.phone}/{p.email}
        </p>
      </div>
    );
  });
}

function AddParticipant({ config }) {
  var [part, setPart] = useState({ name: "", phone: "", email: "" });

  return (
    <div>
      <h3>Add participant</h3>
      <input
        type="text"
        placeholder="Name"
        value={part.name}
        onChange={(e) => setPart({ ...part, name: e.target.value })}
      />
      <input
        type="text"
        placeholder="Phone"
        value={part.phone}
        onChange={(e) => setPart({ ...part, phone: e.target.value })}
      />
      <input
        type="text"
        placeholder="Email"
        value={part.email}
        onChange={(e) => setPart({ ...part, email: e.target.value })}
      />
      <button
        onClick={(e) => {
          config.setParticipants([...config.participants, part]);
          setPart({ name: "", phone: "", email: "" });
        }}
      >
        Add
      </button>
    </div>
  );
}
