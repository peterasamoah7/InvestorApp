"use client"

import { useState } from "react";
import { useRouter } from "next/navigation";

export default function InvestorSearch(){
    const[query, setQuery] = useState("");
    const router = useRouter();

    const searchInvestor = () => {
        if (query && query.length > 0){
            router.push(`?name=${query}&PageNumber=1&PageSize=10`)
        }
    };

    return(
        <>
            <div className="mb-3" style={{ width: "80%", margin: "0 auto" }}>
                <div className="input-group">
                    <input type="text" 
                        className="form-control" 
                        value={query}
                        onChange={(e) => setQuery(e.target.value)} 
                        placeholder="Search by name.."/>
                    <button className="btn btn-primary" type="button" onClick={searchInvestor}>Search</button>
                </div>
            </div>
        </>
    );
}