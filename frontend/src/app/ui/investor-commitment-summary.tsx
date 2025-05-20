"use client"

import Link from "next/link";
import { formatAmount } from "../helpers";

export default function InvestorCommitmentSummary({models, id}: {models: Array<CommitmentSummray> | null, id: string}){
    return(
        <> 
            <div className="d-flex flex-wrap justify-content-start">
                {models?.map((item, i) => (
                    <div key={i} className="stat-card">
                    <Link key={i} href={`/investor-commitments/${id}?aID=${item.id}&pageNumber=1&pageSize=10`} className="card-link">
                        <div className="card-body text-center">
                            <h6 className="card-title">{item.key}</h6>
                            <p className="card-text">{formatAmount(item.total)}</p>
                        </div>
                    </Link>
                    </div>
                ))}
            </div>
        </>
    );
}