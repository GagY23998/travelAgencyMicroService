import {useState} from "react";
const FilterField = ({fieldName})=>{
    <div>
        <label className="field__name">{fieldName}</label>
        <span className="field__value">{}</span>
    </div>
}
const Filter = (props)=>{
    const [filterFields, setFilterFields] = useState();
    return (
      <div className="filter__container">
          <div className="filter__fields">
            
          </div>
          <div className="filter__buttons">
            <span className="btn__search"><button>Search</button></span>
            <span className="btn__reset"><button>Reset</button></span>
          </div>
      </div>  
    );

};

export default Filter;