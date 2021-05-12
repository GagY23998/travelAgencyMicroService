import Review from "../../Review/Review";
import "./Rating.css";
import React from "react";
import * as Components from "../../../containers/Helpers/Components";

const Rating = ({item,subComponent})=>{

    const Component = Components[subComponent];
    return (<article className="ratingItem">
        <div className="hotelSection">
            <Component data={item}/>
        </div>
        <div className="ratingSection">
            {
                item.hotelReviews.map((el,i)=>{
                    return (<Review key={i} item={el}/>);
                })
            }
        </div>
    </article>);
}

export default  Rating;