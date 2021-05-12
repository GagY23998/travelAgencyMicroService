import {useState,useEffect,useCallback} from "react";
import UseApi from "./ApiHook";

const useSliderHook=()=>{
    // const [sliderData,setSliderData] =useState();
    // useEffect(() => {

    //     const GetTopDestinations = async()=> await UseApi("/destinations").get("/topDestinations");
    //     let data =GetTopDestinations();
    //     setSliderData(data);
    //     return () => {
    //         setSliderData(data);
    //     };
    // }, []);
    // return [sliderData];
    const sliderData = [
        {
            picture: require("./../../images/1.jpg"),
            description: "This is really a nojs description mate"
        },
        {
            picture: require("./../../images/2.jpg"),
            description: "No,This is really  a nojs description mate"
        },
        {
            picture: require("./../../images/3.jpg"),
            description: "Ay whatchu know, now This is really  a nojs description mate"
        },
        {
            picture: require("./../../images/4.jpg"),
            description: "Ay whatchu know, now This is really  a nojs description mate"
        }
    ];
    console.log(sliderData);
    return sliderData;
};
export default useSliderHook;