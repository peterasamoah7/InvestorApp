"use client"

import { useRouter } from "next/navigation";
import { formatAmount } from "../helpers";
import Link from "next/link";

export default function Investor({models}: {models: PagedModel<InvestorModel> | null}){
    const router = useRouter();
    const tblHeader = ['ID', 'Name', 'Type', 'Date Added', 'Country', 'TotalCommitment']

    return (
        <>         
            <table className="table">
                <thead>
                    <tr>
                        {tblHeader.map((h, i) => (<th scope="col" key={i}>{h}</th>))}
                    </tr>
                </thead>
                
                <tbody>
                    {models?.items.map((item, i) => (
                    <tr key={i}>
                        <th key={item.id}>{item.id}</th>
                        <td>{item.name}</td>
                        <td>{item.type}</td>
                        <td>{item.dateAdded}</td>
                        <td>{item.country}</td>
                        <td><Link href={`/investor-commitments/${item.id}?aID=All&pageNumber=1&pageSize=10`} className="profile-link">{formatAmount(item.totalCommitment)}</Link></td>
                    </tr>                        
                ))}
                </tbody>
            </table>   
        </>
    );
}