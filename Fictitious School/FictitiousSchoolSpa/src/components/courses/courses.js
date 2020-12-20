import Select from "react-select";

export function Courses({config}) {
  return (
    <div> 
      <h1>Course</h1>
      <Select options={config.mainOptions.map((o) => {
        return {
          value: o.id,
          label: o.name,
          dates: o.dates
        }
      })} onChange={option => config.setCourseOption(option)} />
      {config.courseOption && <Select options={config.courseOption.dates.map((date, index) => {
        return {
          value: index,
          label: date
        }
      })} onChange={option => config.setDateOption(option.label)} /> }
    </div>
  );
}
