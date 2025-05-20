"use client"

import { formatAmount } from "../helpers";

export default function InvestorCommitment({models}: {models: PagedModel<CommitmentModel> | null}){
    const tblHeader = ['ID', 'Asset Class', 'Currency', 'Amount']

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
                        <td>{item.assetClass}</td>
                        <td>{item.currency}</td>
                        <td>{formatAmount(item.amount)}</td>
                    </tr>                        
                ))}
                </tbody>
            </table>   
        </>
    );
}