import "./Review.css";
const Review = ({item})=>{
    console.log(item);
    return (<div className="ReviewContainer">
        <div className="user__container">
            <span className="review__imageContainer">
                <img height="50px" width="50px" src={"data:image/png;base64,"+item.user.picture} alt={item.user.firstName+"image"} />
            </span>
        <span className="ReviewName"><i>{item.user.firstName + " " + item.user.lastName}</i></span>
            </div>
        <div className="ReviewComment">
            <textarea className="review__textarea" defaultValue={item.comment}>
            </textarea>
        </div>
    </div>);
};
export default Review;